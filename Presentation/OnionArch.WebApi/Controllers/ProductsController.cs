using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Features.Commands.Product.CreateProduct;
using OnionArch.Application.Features.Commands.Product.UpdateProduct;
using OnionArch.Application.Features.Queries.Product.GetAllProduct;
using OnionArch.Application.Parametres.RequestParametres;

namespace OnionArch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpPost("ProductAdd")]
        public async Task<IActionResult> ProductAdd([FromBody] CreateProductCommandRequest createProductCommonRequest)
        {
            CreateProductCommandResponse createProductCommandResponse = await mediator.Send(createProductCommonRequest);
            return Ok(createProductCommandResponse);
        }

        [HttpPut("ProductUpdate")]
        public async Task<IActionResult> ProductUpdate([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse = await mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);
        }

    }
}
