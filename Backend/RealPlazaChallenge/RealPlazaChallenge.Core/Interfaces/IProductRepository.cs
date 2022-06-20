using RealPlazaChallenge.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealPlazaChallenge.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<int> AddProduct(Product pr);
        Task<Product> GetById(int id);
        Task<int> UpdateProduct(Product pr);
        Task<int> RemoveProduct(int id);
        Task<List<Product>> GetProductsSearch(string name);
    }
}
