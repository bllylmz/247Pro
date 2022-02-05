using _247Pro.API.Controllers.Base;
using _247Pro.Common.DTOs.Estimate;
using _247Pro.Common.Models;
using _247Pro.Model.Entities;
using _247Pro.Service.Repository.Estimate;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _247Pro.API.Controllers
{
    [Route("Estimate")]
    public class EstimateController : BaseApiController<EstimateController>
    {
        private readonly IEstimateRepository _estimateRepository;
        private readonly IMapper _mapper;

        public EstimateController(
            IEstimateRepository estimateRepository,
            IMapper mapper)
        {
            _estimateRepository = estimateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Permission(Permissions.Estimates_List)]
        public async Task<ActionResult<WebApiResponse<List<EstimateResponse>>>> GetEstimates()
        {
            var estimateResult = _mapper.Map<List<EstimateResponse>>(
                await _estimateRepository.GetDefault(x => x.Id != Guid.Empty, x => x.EstimatesAccounts).ToListAsync());
            if (estimateResult.Count > 0)
            {
                return new WebApiResponse<List<EstimateResponse>>(true, "Success", estimateResult);
            }
            return new WebApiResponse<List<EstimateResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        [Permission(Permissions.Estimates_List)]
        public async Task<ActionResult<WebApiResponse<EstimateResponse>>> GetEstimate(Guid id)
        {
            var estimateResult = _mapper.Map<EstimateResponse>(
                await _estimateRepository.GetByParam(x => x.Id == id, x => x.EstimatesAccounts));
            if (estimateResult != null)
            {
                return new WebApiResponse<EstimateResponse>(true, "Success", estimateResult);
            }
            return new WebApiResponse<EstimateResponse>(false, "Error");
        }

        [HttpPost]
        [Permission(Permissions.Estimates_Create)]
        public async Task<ActionResult<WebApiResponse<EstimateResponse>>> PostEstimate(EstimateRequest request)
        {
            Estimate entity = _mapper.Map<Estimate>(request);
            var insertResult = await _estimateRepository.Add(entity);
            if (insertResult != null)
            {
                EstimateResponse rm = _mapper.Map<EstimateResponse>(insertResult);
                return new WebApiResponse<EstimateResponse>(true, "Success", rm);
            }
            return new WebApiResponse<EstimateResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        [Permission(Permissions.Estimates_Update)]
        public async Task<ActionResult<WebApiResponse<EstimateResponse>>> PutEstimate(Guid id, EstimateRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                Estimate entity = await _estimateRepository.GetByParam(x=>x.Id == id, x=>x.EstimatesAccounts);
                if (entity == null)
                    return NotFound();

                //Kaynaktan gelen bir değiklik varsa onu entity üzerinde günceller.
                _mapper.Map(request, entity);

                var manyUpdateResult = await _estimateRepository.MantToManyUpdate(entity);
                if (manyUpdateResult != null)
                {
                    EstimateResponse rm = _mapper.Map<EstimateResponse>(manyUpdateResult);
                    return new WebApiResponse<EstimateResponse>(true, "Success", rm);
                }
                return new WebApiResponse<EstimateResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        [Permission(Permissions.Estimates_Delete)]
        public async Task<ActionResult<WebApiResponse<EstimateResponse>>> DeleteEstimate(Guid id)
        {
            var estimate = await _estimateRepository.GetById(id);
            if (estimate != null)
            {
                if (await _estimateRepository.Remove(estimate.Id))
                    return new WebApiResponse<EstimateResponse>(true, "Success", _mapper.Map<EstimateResponse>(estimate));
                else
                    return new WebApiResponse<EstimateResponse>(false, "Error");
            }
            return new WebApiResponse<EstimateResponse>(false, "Error");
        }

    }
}
