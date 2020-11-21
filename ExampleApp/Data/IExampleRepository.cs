using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleApp.Data
{
    public interface IExampleRepository
    {
        Task AddAsync(Example example);
        Task<Example> GetAsync(Guid id);
        Task<List<Example>> GetAllAsync();
        Task UpdateAsync(Example example);
        Task DeleteAsync(Example example);
    }
}
