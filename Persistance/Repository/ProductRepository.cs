using Application.Contracts.Persistance;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repository
{
    public class ProductRepository :AsyncRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {
            
        }
        new public async Task<List<Product>?> GetAll()
        {
            return await _shopDbContext.Products
                .Include(p => p.ProductCategory)
                .ToListAsync();
        }
        //public async Task<List<Product>> GetProductsAsync()
        //{
        //    return await _shopDbContext.Products
        //        .Include(p => p.ProductCategory)
        //        .ToListAsync();
        //}
    }
}
