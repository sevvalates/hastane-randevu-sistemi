using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.DoctorCQRS.Queries;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List() //GetAll
        {
            var result = await _mediator.Send(new GetDoctorsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDoctorQueryRequest(id));
            return Ok(result);
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }
        */
        /// //////////////
        [HttpPost]
        public async Task<IActionResult> Create(CreateDoctorCommandRequest request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //25.10.24  ModelState doğrulama hatalarını JSON olarak döner
            }

            var doctorExists = await _mediator.Send(new GetDoctorQueryRequest(request.SocialSecurityNumber));
            if (doctorExists != null)
            {
                return Conflict(new { message = "A doctor with this SSN already exists." });
                //return BadRequest("A patient with this Social Security Number already exists.");
            }

            var result = await _mediator.Send(request);
            return Created("", result);
        }
        /// //////////////

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDoctorCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveDoctorCommandRequest(id));
            return Ok();
        }

    }
}
