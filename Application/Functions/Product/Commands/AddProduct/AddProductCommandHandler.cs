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

namespace Application.Functions.Product.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IMapper mapper, IProductRepository productRepository) 
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<BaseResponse> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                return new BaseResponse(false, "Problem z walidacja danych");
            }

            var product = _mapper.Map<Domain.Entites.Product>(request);

            product.CreatedBy = "Test";
            product.CreatedDate = new DateTime(2023, 10, 03);
            product.LastModifiedBy = "Test";
            product.LastModifiedDate = new DateTime(2023, 10, 03);

            var addProduct = await _productRepository.AddAsync(product);

            if(addProduct == null)
            {
                return new BaseResponse(false, "Something went wrong");
            }

            return new BaseResponse(true, "Dodano nowy produkt");
        }
    }
}
