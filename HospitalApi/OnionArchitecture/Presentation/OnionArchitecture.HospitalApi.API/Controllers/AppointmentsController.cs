using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.AppointmentCQRS.Queries;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List() //GetAll
        {
            var result = await _mediator.Send(new GetAppointmentsQueryRequest());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAppointmentQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentCommandRequest request)
        {

            // var data = JsonSerializer.Serialize(request).ToString(); ;
            var result = await _mediator.Send(request);

            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                return Conflict(new { message = result.ErrorMessage });// Hata mesajı varsa 409 Conflict dön
                // Hata mesajı varsa 409 Conflict dön
            }

            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppointmentCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveAppointmentCommandRequest(id));
            return Ok();
        }

    }
}
