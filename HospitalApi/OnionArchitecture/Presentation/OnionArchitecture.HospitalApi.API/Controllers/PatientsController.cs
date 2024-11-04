using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.PatientCQRS.Queries;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List() //GetAll
        {
            var result = await _mediator.Send(new GetPatientsQueryRequest());
            return Ok(result);
        }


        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetPatientQueryRequest(id));
            return Ok(result);
        }
        */

        [HttpGet("{socialSecurityNumber}")]
        public async Task<IActionResult> GetById(long socialSecurityNumber)
        {
            var result = await _mediator.Send(new GetPatientQueryRequest(socialSecurityNumber));
            return Ok(result);
        }

        /* 22.10 create
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }
        */
        /// //////////////
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommandRequest request)
        {
            var patientExists = await _mediator.Send(new GetPatientQueryRequest(request.SocialSecurityNumber));
            if (patientExists != null)
            {
                return Conflict(new { message = "A patient with this SSN already exists." });
                //return BadRequest("A patient with this Social Security Number already exists.");
            }

            var result = await _mediator.Send(request);
            return Created("", result);
        }
        /// //////////////


        [HttpPut]
        public async Task<IActionResult> Update(UpdatePatientCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemovePatientCommandRequest(id));
            return Ok();
        }


    }
}
