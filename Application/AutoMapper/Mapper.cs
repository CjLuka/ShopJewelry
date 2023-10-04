using Application.Functions.Product.Commands.AddProduct;
using Application.Functions.Product.Queries.GetAllProducts;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            //Product Queries
            CreateMap<Product, GetAllProductsDto>()
                .ForMember(dest => dest.NameCategory, opt => opt.MapFrom(src => src.ProductCategory.Name));

            //Product Commands
            CreateMap<Product, AddProductCommand>().ReverseMap();
        }
    }
}
