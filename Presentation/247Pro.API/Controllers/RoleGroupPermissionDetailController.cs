using _247Pro.API.Controllers.Base;
using _247Pro.Common.DTOs.RoleGroupPermissionDetail;
using _247Pro.Common.Models;
using _247Pro.Model.Entities;
using _247Pro.Service.Repository.RoleGroupPermissionDetail;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _247Pro.API.Controllers
{
    [Route("RoleGroupPermissionDetail")]
    public class RoleGroupPermissionDetailController : BaseApiController<RoleGroupPermissionDetailController>
    {
        private readonly IRoleGroupPermissionDetailRepository _roleGroupPermissionDetailRepository;
        private readonly IMapper _mapper;

        public RoleGroupPermissionDetailController(
            IRoleGroupPermissionDetailRepository roleGroupPermissionDetailRepository,
            IMapper mapper)
        {
            _roleGroupPermissionDetailRepository = roleGroupPermissionDetailRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<RoleGroupPermissionDetailResponse>>>> GetRoleGroupPermissionDetails()
        {
            var roleGroupPermissionDetailResult =
                _mapper.Map<List<RoleGroupPermissionDetailResponse>>(
                    await _roleGroupPermissionDetailRepository.GetDefault(x => x.Id != Guid.Empty, 
                    x => x.RoleGroup, 
                    x => x.RolePermission).ToListAsync());

            if (roleGroupPermissionDetailResult.Count > 0)
            {
                return new WebApiResponse<List<RoleGroupPermissionDetailResponse>>(true, "Success", roleGroupPermissionDetailResult);
            }
            return new WebApiResponse<List<RoleGroupPermissionDetailResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<RoleGroupPermissionDetailResponse>>> GetRoleGroupPermissionDetail(Guid id)
        {
            var roleGroupPermissionDetailResult =
                  _mapper.Map<RoleGroupPermissionDetailResponse>(
                    await _roleGroupPermissionDetailRepository.GetByParam(x => x.Id == id,
                    x => x.RoleGroup,
                    x => x.RolePermission));
            if (roleGroupPermissionDetailResult != null)
            {
                return new WebApiResponse<RoleGroupPermissionDetailResponse>(true, "Success", roleGroupPermissionDetailResult);
            }
            return new WebApiResponse<RoleGroupPermissionDetailResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<RoleGroupPermissionDetailResponse>>> PostRoleGroupPermissionDetail(RoleGroupPermissionDetailRequest request)
        {
            RoleGroupPermissionDetail entity =
                _mapper.Map<RoleGroupPermissionDetail>(request);
            var insertResult = await _roleGroupPermissionDetailRepository.Add(entity);
            if (insertResult != null)
            {
                RoleGroupPermissionDetailResponse rm = _mapper.Map<RoleGroupPermissionDetailResponse>(insertResult);
                return new WebApiResponse<RoleGroupPermissionDetailResponse>(true, "Success", rm);
            }
            return new WebApiResponse<RoleGroupPermissionDetailResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<RoleGroupPermissionDetailResponse>>> PutRoleGroupPermissionDetail(Guid id, RoleGroupPermissionDetailRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                RoleGroupPermissionDetail entity = await _roleGroupPermissionDetailRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                //Kaynaktan gelen bir değiklik varsa onu entity üzerinde günceller.
                _mapper.Map(request, entity);

                var updateResult = await _roleGroupPermissionDetailRepository.Update(entity);
                if (updateResult != null)
                {
                    RoleGroupPermissionDetailResponse rm = _mapper.Map<RoleGroupPermissionDetailResponse>(updateResult);
                    return new WebApiResponse<RoleGroupPermissionDetailResponse>(true, "Success", rm);
                }
                return new WebApiResponse<RoleGroupPermissionDetailResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<RoleGroupPermissionDetailResponse>>> DeleteRoleGroupPermissionDetail(Guid id)
        {
            var roleGroupPermissionDetail = await _roleGroupPermissionDetailRepository.GetById(id);
            if (roleGroupPermissionDetail != null)
            {
                if (await _roleGroupPermissionDetailRepository.Remove(roleGroupPermissionDetail.Id))
                    return new WebApiResponse<RoleGroupPermissionDetailResponse>(true, "Success", _mapper.Map<RoleGroupPermissionDetailResponse>(roleGroupPermissionDetail));
                else
                    return new WebApiResponse<RoleGroupPermissionDetailResponse>(false, "Error");
            }
            return new WebApiResponse<RoleGroupPermissionDetailResponse>(false, "Error");
        }

    }
}
