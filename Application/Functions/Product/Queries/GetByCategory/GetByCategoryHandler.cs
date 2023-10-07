using Application.Contracts.Persistance;
using Application.Functions.Product.Queries.GetAllProducts;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Product.Queries.GetByCategory
{
    public class GetByCategoryHandler : IRequestHandler<GetByCategoryQuery, BaseResponse<List<GetByCategoryDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetByCategoryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse<List<GetByCategoryDto>>> Handle(GetByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetByCategoryAsync(request.CategoryId);

            if(products.Count == 0) 
            {
                return new BaseResponse<List<GetByCategoryDto>>(false, "There are no products in the given category");
            }

            if(products.Any())
            {
                return new BaseResponse<List<GetByCategoryDto>>(_mapper.Map<List<GetByCategoryDto>>(products), true);
            }

            return new BaseResponse<List<GetByCategoryDto>>(false, "Something went wrong");
        }
    }
}
