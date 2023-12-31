﻿using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistance
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        //Task <List<Product>> GetProductsAsync ();
        Task<List<Product>> GetByCategoryAsync(int categoryId);
    }
}
