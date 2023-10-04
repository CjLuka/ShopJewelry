using Application.Functions.Product.Commands.AddProduct;
using Application.Functions.Product.Queries.GetAllProducts;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("allProducts")]
        public async Task<BaseResponse<List<GetAllProductsDto>>> GetAllProducts()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }
        [HttpPost]
        [Route("addProduct")]
        public async Task<BaseResponse> AddProduct([FromBody] AddProductCommand request)
        {
            return await _mediator.Send(request);
        }
    }
}
