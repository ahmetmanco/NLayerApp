﻿using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Entities;
using Nlayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int CategoryId)
        {
            return await _context.Categories.Include(x => x.Products).Where(x => x.Id == CategoryId).SingleOrDefaultAsync();
        }
    }
}
