using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Product.Queries.GetByCategory
{
    public class GetByCategoryDto 
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string NameCategory { get; set; }
    }
}
