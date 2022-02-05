using _247Pro.API.Controllers.Base;
using _247Pro.Common.DTOs.RoleGroup;
using _247Pro.Common.Models;
using _247Pro.Model.Entities;
using _247Pro.Service.Repository.RoleGroup;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _247Pro.API.Controllers
{
    [Route("RoleGroup")]
    public class RoleGroupController : BaseApiController<RoleGroupController>
    {
        private readonly IRoleGroupRepository _roleGroupRepository;
        private readonly IMapper _mapper;

        public RoleGroupController(
            IRoleGroupRepository roleGroupRepository,
            IMapper mapper)
        {
            _roleGroupRepository = roleGroupRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<RoleGroupResponse>>>> GetRoleGroups()
        {
            var roleGroupResult = _mapper.Map<List<RoleGroupResponse>>(
                await _roleGroupRepository.GetDefault(x => x.Id != Guid.Empty).ToListAsync());
            if (roleGroupResult.Count > 0)
            {
                return new WebApiResponse<List<RoleGroupResponse>>(true, "Success", roleGroupResult);
            }
            return new WebApiResponse<List<RoleGroupResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<RoleGroupResponse>>> GetRoleGroup(Guid id)
        {
            var roleGroupResult = _mapper.Map<RoleGroupResponse>(
                await _roleGroupRepository.GetByParam(x=>x.Id == id));
            if (roleGroupResult != null)
            {
                return new WebApiResponse<RoleGroupResponse>(true, "Success", roleGroupResult);
            }
            return new WebApiResponse<RoleGroupResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<RoleGroupResponse>>> PostRoleGroup(RoleGroupRequest request)
        {
            RoleGroup entity = _mapper.Map<RoleGroup>(request);
            var insertResult = await _roleGroupRepository.Add(entity);
            if (insertResult != null)
            {
                RoleGroupResponse rm = _mapper.Map<RoleGroupResponse>(insertResult);
                return new WebApiResponse<RoleGroupResponse>(true, "Success", rm);
            }
            return new WebApiResponse<RoleGroupResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<RoleGroupResponse>>> PutRoleGroup(Guid id, RoleGroupRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                RoleGroup entity = await _roleGroupRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Kaynaktan gelen bir değiklik varsa onu entity üzerinde günceller.
                _mapper.Map(request, entity);

                var updateResult = await _roleGroupRepository.Update(entity);
                if (updateResult != null)
                {
                    RoleGroupResponse rm = _mapper.Map<RoleGroupResponse>(updateResult);
                    return new WebApiResponse<RoleGroupResponse>(true, "Success", rm);
                }
                return new WebApiResponse<RoleGroupResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<RoleGroupResponse>>> DeleteRoleGroup(Guid id)
        {
            var roleGroup = await _roleGroupRepository.GetById(id);
            if (roleGroup != null)
            {
                if (await _roleGroupRepository.Remove(roleGroup.Id))
                    return new WebApiResponse<RoleGroupResponse>(true, "Success", _mapper.Map<RoleGroupResponse>(roleGroup));
                else
                    return new WebApiResponse<RoleGroupResponse>(false, "Error");
            }
            return new WebApiResponse<RoleGroupResponse>(false, "Error");
        }

    }
}
