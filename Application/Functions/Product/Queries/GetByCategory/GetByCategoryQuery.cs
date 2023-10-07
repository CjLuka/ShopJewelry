using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Product.Queries.GetByCategory
{
    public class GetByCategoryQuery : IRequest<BaseResponse<List<GetByCategoryDto>>>
    {
        public int CategoryId { get; set; }
    }
}
