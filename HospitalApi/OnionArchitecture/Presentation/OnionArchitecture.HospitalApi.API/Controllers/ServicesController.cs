using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.ServiceCQRS.Queries;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> List() //GetAll
        {
            var result = await _mediator.Send(new GetServicesQueryRequest());
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetServiceQueryRequest(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveServiceCommandRequest(id));
            return Ok();
        }


    }
}
