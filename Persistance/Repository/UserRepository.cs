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
    public class UserRepository : AsyncRepository<User>, IUserRepository
    {
        public UserRepository(ShopDbContext shopDbContext) : base(shopDbContext)
        {

        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _shopDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
