using MediatR;
using MediatRExample.WebApi.Med.Command;
using MediatRExample.WebApi.Med.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRExample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("Id")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var query = new GetProductByIdQuery() { Id = Id };
            return Ok(await _mediator.Send(query));
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProducts();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
