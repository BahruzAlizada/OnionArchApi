using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Constant;
using OnionArch.Application.CustomAttributes;
using OnionArch.Application.Features.Commands.Product.CreateProduct;
using OnionArch.Application.Features.Commands.Product.DeleteProduct;
using OnionArch.Application.Features.Commands.Product.UpdateProduct;
using OnionArch.Application.Features.Queries.Product.GetAllProduct;
using OnionArch.Application.Features.Queries.Product.GetByIdProduct;
using OnionArch.Application.Parametres.RequestParametres;

namespace OnionArch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Admin")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        #region GetProducts
        [HttpGet("GetProducts")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = Application.Enums.ActionType.Reading, Definition = "Get Products")]
        public async Task<IActionResult> GetProducts([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }
        #endregion

        #region GetProduct
        [HttpGet("GetProduct")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = Application.Enums.ActionType.Reading, Definition = "Get by Id Product")]
        public async Task<IActionResult> GetProduct([FromQuery] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse getByIdProductQueryResponse = await mediator.Send(getByIdProductQueryRequest);
            return Ok(getByIdProductQueryResponse);
        }
        #endregion

        #region ProductAdd
        [HttpPost("ProductAdd")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = Application.Enums.ActionType.Writing, Definition = "Add Product")]
        public async Task<IActionResult> ProductAdd([FromBody] CreateProductCommandRequest createProductCommonRequest)
        {
            CreateProductCommandResponse createProductCommandResponse = await mediator.Send(createProductCommonRequest);
            return Ok(createProductCommandResponse);
        }
        #endregion

        #region ProductUpdate
        [HttpPut("ProductUpdate")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = Application.Enums.ActionType.Updateing, Definition = "Update Product")]
        public async Task<IActionResult> ProductUpdate([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse = await mediator.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);
        }
        #endregion

        #region ProductDelete
        [HttpDelete("ProductDelete")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = Application.Enums.ActionType.Deleting, Definition = "Delete Product")]
        public async Task<IActionResult> ProductDelete([FromQuery] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse deleteProductCommandResponse = await mediator.Send(deleteProductCommandRequest);
            return Ok(deleteProductCommandResponse);
        }
        #endregion

    }
}
