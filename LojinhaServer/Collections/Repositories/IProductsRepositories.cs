using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojinhaServer.Collections.Repositories
{
    public interface IProductsRepositories
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(String id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);

    }
}