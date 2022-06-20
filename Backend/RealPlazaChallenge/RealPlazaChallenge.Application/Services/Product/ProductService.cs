using RealPlazaChallenge.Application.ViewModels;
using RealPlazaChallenge.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RealPlazaChallenge.Application.InputModel;

namespace RealPlazaChallenge.Application.Services.Product
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ProductService" en el código y en el archivo de configuración a la vez.
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> AddProduct(ProductModel newP)
        {
            Core.Entities.Product pro = new Core.Entities.Product
            {
                Name = newP.Name,
                Description = newP.Description,
                Status = newP.Status,
                Price = newP.Price,
                Discount = newP.Discount,
                Quantity = newP.Quantity,
                Inserted_time = DateTime.Now,
                Updated_time = DateTime.Now
            };
            var id = await _productRepository.AddProduct(pro);

            return id;
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var product = await _productRepository.GetById(id);

            ProductViewModel productVM = new ProductViewModel(product);

            return productVM;
        }

        public async Task<List<ProductViewModel>> GetProductsSearch(string name)
        {
            var products = await _productRepository.GetProductsSearch(name);

            var productsM = products
                .Select(u => new ProductViewModel(u))
                .ToList();

            return productsM;
        }

        public async Task<int> UpdateProduct(ProductModel newP)
        {
            Core.Entities.Product pro = new Core.Entities.Product
            {
                Name = newP.Name,
                Description = newP.Description,
                Status = newP.Status,
                Price = newP.Price,
                Discount = newP.Discount,
                Quantity = newP.Quantity,
                Inserted_time = newP.Inserted_time,
                Updated_time = DateTime.Now
            };

            var result = await _productRepository.UpdateProduct(pro);

            return result;
        }

        public async Task<int> RemoveProduct(int id)
        {   
            var result = await _productRepository.RemoveProduct(id);

            return result;
        }

        public async Task<List<ProductViewModel>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            var productsM = products
                .Select(u => new ProductViewModel(u))
                .ToList();

            return productsM;
        }
    }
}
