using Hireplicity.CodeChallenge.Api.Data;
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
        private readonly IHireplicityRepositories _hireplicityRepositories;

        public ServiceRequestController(IHireplicityRepositories hireplicityRepositories)
        {
            _hireplicityRepositories = hireplicityRepositories;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all Service Requests", Description = "Used by Dev")]
        [ProducesResponseType(typeof(IEnumerable<ServiceRequest>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<ServiceRequest> serviceRequests = await _hireplicityRepositories.GetAllAsync();

                if (serviceRequests.Any()) return Ok(serviceRequests);
                else return NoContent();


            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get Service Requests by Id", Description = "Used by Dev")]
        [ProducesResponseType(typeof(ServiceRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                ServiceRequest serviceRequest = await _hireplicityRepositories.GetByIdAsync(id);

                if (serviceRequest != null) return Ok(serviceRequest);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost()]
        [SwaggerOperation(Summary = "Insert new entry for Service Requests", Description = "Used by Dev")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Insert(ServiceRequest serviceRequest)
        {
            try
            {
                ServiceRequest result = await _hireplicityRepositories.InsertAsync(serviceRequest);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update entry Service Requests by Id", Description = "Used by Dev")]
        [ProducesResponseType(typeof(ServiceRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(Guid id, ServiceRequest data)
        {
            try
            {
                ServiceRequest serviceRequest = await _hireplicityRepositories.UpdateAsync(id, data);

                if (serviceRequest != null) return Ok(serviceRequest);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete entry Service Requests by Id", Description = "Used by Dev")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                bool isSuccess = await _hireplicityRepositories.DeleteAsync(id);

                if (!isSuccess) return NotFound();

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
