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

        //pobranie wszystkich produktów
        new public async Task<List<Product>?> GetAll()
        {
            return await _shopDbContext.Products
                .Include(p => p.ProductCategory)
                .ToListAsync();
        }

        //pobranie wszystkich produktów po kategorii
        public async Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            return await _shopDbContext.Products
                .Include(p => p.ProductCategory)
                .Where(x => x.ProductCategoryId== categoryId)
                .ToListAsync();
        }

    }
}
