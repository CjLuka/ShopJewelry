using Application.Responses;
using Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<BaseResponse<List<GetAllProductsDto>>>
    {
        
    }
}
