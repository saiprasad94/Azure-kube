using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleApp.Data
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly ExampleDbContext exampleDbContext;

        public ExampleRepository(ExampleDbContext exampleDbContext)
        {
            this.exampleDbContext = exampleDbContext;
        }

        public async Task AddAsync(Example example)
        {
            exampleDbContext.Examples.Add(example);
            await exampleDbContext.SaveChangesAsync();
        }

        public async Task<Example> GetAsync(Guid id)
        {
            return await exampleDbContext.Examples.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Example>> GetAllAsync()
        {
            return await exampleDbContext.Examples.ToListAsync();
        }

        public async Task UpdateAsync(Example item)
        {
            exampleDbContext.Entry(item).State = EntityState.Modified;
            await exampleDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Example item)
        {
            exampleDbContext.Examples.Remove(item);
            await exampleDbContext.SaveChangesAsync();
        }
    }
}
