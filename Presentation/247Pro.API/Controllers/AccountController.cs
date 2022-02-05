using _247Pro.Common.DTOs.Login;
using _247Pro.Common.DTOs.UserAccount;
using _247Pro.Common.Extensions;
using _247Pro.Common.Models;
using _247Pro.Service.Repository.UserAccount;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _247Pro.API.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccountRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AccountController(
            IUserAccountRepository userRepository,
            IConfiguration configuration,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        //http://localhost:5000/account?Email=admin@admin.com&Password=123
        [HttpGet]
        public async Task<WebApiResponse<UserAccountResponse>> Login([FromQuery] LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.GetByParam(x => x.LoginEmail == request.Email && x.PasswordHash == request.Password);
                if (result != null)
                {
                    UserAccountResponse rm = _mapper.Map<UserAccountResponse>(result);
                    rm.AccessToken = GetAccessToken(rm, request.Password);
                    return new WebApiResponse<UserAccountResponse>(true, "Success", rm);

                }
            }
            return new WebApiResponse<UserAccountResponse>(false,
                ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ToString());
        }

        private GetAccessToken GetAccessToken(UserAccountResponse rm, string password)
        {
            var claims = new List<Claim>
            {
                //System.IdentityModel.Tokens.Jwt;
                new Claim(JwtRegisteredClaimNames.Email,rm.LoginEmail),
                new Claim(JwtRegisteredClaimNames.Jti,rm.Id.ToString())
            };

            //JWT 

            var systemSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
            var signingCredential = new SigningCredentials(systemSecurityKey, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Tokens:Expires"]));
            var ticks = expires.ToUnixTime();

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _configuration["Tokens:Issuer"],
                audience: _configuration["Tokens:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: signingCredential
                );

            return new GetAccessToken
            {
                TokenType = "247ProAccessToken",
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Expires = ticks,
                RefreshToken = $"{rm.LoginEmail}_{password}_{ticks}".Encrypt()
            };
        }
        //http://localhost:5000/account/refreshtoken?Email=admin@admin.com&Refresh_Token=YWRtaW5AYWRtaW4uY29tXzEyM18xNjQzNzUxNTY0
        [HttpGet("refreshtoken")]
        public async Task<WebApiResponse<GetAccessToken>> RefreshToken([FromQuery] RefreshToken request)
        {
            if (string.IsNullOrEmpty(request.Refresh_Token))
                throw new Exception("Invalid Refresh Token");

            var key = request.Refresh_Token.Decrypt();
            var userInfo = key.Split('_');

            if (userInfo.Length < 3 || userInfo[0] != request.Email)
                throw new Exception("Geçersiz Refresh Token");

            var result = await _userRepository.GetByParam(x => x.LoginEmail == userInfo[0] && x.PasswordHash == userInfo[1]);
            if (result != null)
            {
                UserAccountResponse rm = _mapper.Map<UserAccountResponse>(result);
                rm.AccessToken = GetAccessToken(rm, userInfo[1]);
                return new WebApiResponse<GetAccessToken>(true, "Success", rm.AccessToken);
            }
            return new WebApiResponse<GetAccessToken>(false, "User Not Found");

        }


    }
}
