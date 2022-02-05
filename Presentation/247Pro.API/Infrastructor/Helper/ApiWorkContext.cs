using _247Pro.Common.DTOs.UserAccount;
using _247Pro.Common.WorkContext;
using _247Pro.Service.Repository.UserAccount;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace _247Pro.API.Infrastructor.Helper
{
    public class ApiWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserAccountRepository _userRepository;
        private readonly IMapper _mapper;
        public ApiWorkContext(
            IHttpContextAccessor httpContextAccessor,
            IUserAccountRepository userRepository,
            IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _mapper = mapper;

        }
        public UserAccountResponse CurrentUser 
        { 
            get
            {
                //Microsoft.AspNetCore.Authentication.JwtBearer
                var authResult = _httpContextAccessor.HttpContext.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme).Result;
                if (!authResult.Succeeded)
                    return null;

                var email = authResult.Principal.Claims.FirstOrDefault(x => x.Type == System.Security.Claims.ClaimTypes.Email).Value;
                //System.IdentityModel.Tokens.Jwt
                var userId = authResult.Principal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
                UserAccountResponse user = _mapper.Map<UserAccountResponse>(_userRepository.GetById(System.Guid.Parse(userId)).Result);
                return user;
            }
            set 
            {
                CurrentUser = value;
            }
        }
    }
}
