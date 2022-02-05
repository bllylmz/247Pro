using _247Pro.API.Controllers.Base;
using _247Pro.Common.DTOs.UserAccount;
using _247Pro.Common.Models;
using _247Pro.Model.Entities;
using _247Pro.Service.Repository.UserAccount;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _247Pro.API.Controllers
{
    [Route("UserAccount")]
    public class UserAccountController : BaseApiController<UserAccountController>
    {
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IMapper _mapper;

        public UserAccountController(
            IUserAccountRepository userAccountRepository,
            IMapper mapper)
        {
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Permission(Permissions.Accounts_List)]
        public async Task<ActionResult<WebApiResponse<List<UserAccountResponse>>>> GetUserAccounts()
        {
            UserAccountResponse user = WorkContext.CurrentUser;
            var userAccountResult = _mapper.Map<List<UserAccountResponse>>(
                await _userAccountRepository.GetDefault(x => x.Id != Guid.Empty,
                x => x.RoleGroup,
                x => x.EstimatesAccounts).ToListAsync());
            if (userAccountResult.Count > 0)
            {
                return new WebApiResponse<List<UserAccountResponse>>(true, "Success", userAccountResult);
            }
            return new WebApiResponse<List<UserAccountResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        [Permission(Permissions.Accounts_List)]
        public async Task<ActionResult<WebApiResponse<UserAccountResponse>>> GetUserAccount(Guid id)
        {
            var userAccountResult = _mapper.Map<UserAccountResponse>(
                await _userAccountRepository.GetByParam(x => x.Id == id,
                x => x.RoleGroup,
                x => x.EstimatesAccounts));
            if (userAccountResult != null)
            {
                return new WebApiResponse<UserAccountResponse>(true, "Success", userAccountResult);
            }
            return new WebApiResponse<UserAccountResponse>(false, "Error");
        }

        [HttpPost]
        [Permission(Permissions.Accounts_Create)]
        public async Task<ActionResult<WebApiResponse<UserAccountResponse>>> PostUserAccount(UserAccountRequest request)
        {
            UserAccount entity = _mapper.Map<UserAccount>(request);
            var insertResult = await _userAccountRepository.Add(entity);
            if (insertResult != null)
            {
                UserAccountResponse rm = _mapper.Map<UserAccountResponse>(insertResult);
                return new WebApiResponse<UserAccountResponse>(true, "Success", rm);
            }
            return new WebApiResponse<UserAccountResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        [Permission(Permissions.Accounts_Update)]
        public async Task<ActionResult<WebApiResponse<UserAccountResponse>>> PutUserAccount(Guid id, UserAccountRequest request)
        {
            UserAccountResponse user = WorkContext.CurrentUser;
            if (id != request.Id)
                return BadRequest();

            try
            {
                UserAccount entity = await _userAccountRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Kaynaktan gelen bir değiklik varsa onu entity üzerinde günceller.
                _mapper.Map(request, entity);

                var updateResult = await _userAccountRepository.Update(entity);
                if (updateResult != null)
                {
                    UserAccountResponse rm = _mapper.Map<UserAccountResponse>(updateResult);
                    return new WebApiResponse<UserAccountResponse>(true, "Success", rm);
                }
                return new WebApiResponse<UserAccountResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        [Permission(Permissions.Accounts_Delete)]
        public async Task<ActionResult<WebApiResponse<UserAccountResponse>>> DeleteUserAccount(Guid id)
        {
            var userAccount = await _userAccountRepository.GetById(id);
            if (userAccount != null)
            {
                if (await _userAccountRepository.Remove(userAccount.Id))
                    return new WebApiResponse<UserAccountResponse>(true, "Success", _mapper.Map<UserAccountResponse>(userAccount));
                else
                    return new WebApiResponse<UserAccountResponse>(false, "Error");
            }
            return new WebApiResponse<UserAccountResponse>(false, "Error");
        }

    }
}
