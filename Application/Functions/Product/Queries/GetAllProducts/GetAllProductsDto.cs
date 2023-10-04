using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Functions.Product.Queries.GetAllProducts
{
    public class GetAllProductsDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string NameCategory { get; set; }
    }
}
