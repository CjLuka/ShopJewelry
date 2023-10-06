using Application.Contracts.Persistance;
using Domain.Entites;
using Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class ProductCategoryRepository : AsyncRepository<ProductCategory> ,IProductCategoryRepository
    {
        public ProductCategoryRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {

        }

    }
}
