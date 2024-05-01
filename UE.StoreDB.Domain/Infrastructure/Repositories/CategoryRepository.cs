using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE.StoreDB.Domain.Core.Entities;
using UE.StoreDB.Domain.Infrastructure.Data;

namespace UE.StoreDB.Domain.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Sincrono: peticio FIFO
        //public IEnumerable<Category> GetAll()
        //{
        //    return _dbContext
        //            .Category
        //            .Where(c=> c.IsActive == true)
        //            .ToList();
        //}
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext
                    .Category
                    .Where(c => c.IsActive == true)
                    .ToListAsync();
        }
        public async Task<Category> GetById(int id) 
        {
            return await _dbContext
                    .Category
                    .Where(c => c.IsActive == true && c.Id == id)
                    .FirstOrDefaultAsync();

        }

    }
}
