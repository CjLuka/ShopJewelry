using Application.Contracts.Persistance;
using Application.Responses;
using AutoMapper;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Product.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, BaseResponse<List<GetAllProductsDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public GetAllProductsHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task <BaseResponse<List<GetAllProductsDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll();
            if (products == null || !products.Any())
            {
                return new BaseResponse<List<GetAllProductsDto>>(false, "Brak produktów");
            }

            return new BaseResponse<List<GetAllProductsDto>>(_mapper.Map<List<GetAllProductsDto>>(products), true);
        }
    }
}
