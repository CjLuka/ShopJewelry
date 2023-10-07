using Application.Functions.Product.Commands.AddProduct;
using Application.Functions.Product.Queries.GetAllProducts;
using Application.Functions.Product.Queries.GetByCategory;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        [Route("AllProducts")]
        public async Task<BaseResponse<List<GetAllProductsDto>>> GetAllProducts()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }

        [HttpGet]
        [Route("ProductByCategory/{id}")]
        public async Task<BaseResponse<List<GetByCategoryDto>>> GetByCategory(int categoryId)
        {
            return await _mediator.Send(new GetByCategoryQuery() { CategoryId = categoryId});
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        [Route("Add")]
        public async Task<BaseResponse> AddProduct([FromBody] AddProductCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<BaseResponse> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

    }
}
