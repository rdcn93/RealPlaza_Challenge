using RealPlazaChallenge.Application.InputModel;
using RealPlazaChallenge.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RealPlazaChallenge.Application.Services.Product
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProducts();
        Task<int> AddProduct(ProductModel newProduct);
        Task<ProductViewModel> GetById(int id);
        Task<int> UpdateProduct(ProductModel product);
        Task<int> RemoveProduct(int id);
        Task<List<ProductViewModel>> GetProductsSearch(string name);
    }
}
