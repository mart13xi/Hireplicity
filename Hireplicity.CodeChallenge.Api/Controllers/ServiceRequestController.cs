using AutoMapper;
using Hireplicity.CodeChallenge.Api.Data;
using Hireplicity.CodeChallenge.Api.Models;
using Hireplicity.CodeChallenge.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Hireplicity.CodeChallenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHireplicityRepositories _hireplicityRepositories;

        public ServiceRequestController(IMapper mapper, IHireplicityRepositories hireplicityRepositories)
        {
            _mapper = mapper;
            _hireplicityRepositories = hireplicityRepositories;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all Service Requests", Description = "Used by Dev")]
        [ProducesResponseType(typeof(IEnumerable<ServiceRequestModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<ServiceRequest> serviceRequests = await _hireplicityRepositories.GetAllAsync();
                IEnumerable<ServiceRequestModel> serviceRequestModels = _mapper.Map<IEnumerable<ServiceRequestModel>>(serviceRequests);

                if (serviceRequestModels.Any()) return Ok(serviceRequestModels);
                else return NoContent();


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Service Requests by Id", Description = "Used by Dev")]
        [ProducesResponseType(typeof(IEnumerable<ServiceRequestModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                ServiceRequest serviceRequest = await _hireplicityRepositories.GetByIdAsync(id);
                ServiceRequestModel serviceRequestModels = _mapper.Map<ServiceRequestModel>(serviceRequest);

                if (serviceRequestModels != null) return Ok(serviceRequestModels);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
