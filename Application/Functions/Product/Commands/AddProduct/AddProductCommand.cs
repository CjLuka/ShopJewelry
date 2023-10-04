using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Product.Commands.AddProduct
{
    public class AddProductCommand : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
