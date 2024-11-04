using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Commands;
using OnionArchitecture.HospitalApi.Application.Features.CQRS.CorporationCQRS.Queries;
using System.Threading.Tasks;

namespace OnionArchitecture.HospitalApi.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CorporationsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CorporationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List() //GetAll
        {
            var result = await _mediator.Send(new GetCorporationsQueryRequest());
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCorporationQueryRequest(id));
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateCorporationCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCorporationCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveCorporationCommandRequest(id));
            return Ok();
        }

    }
}
