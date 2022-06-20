using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RealPlazaChallenge.Core.Entities;
using RealPlazaChallenge.Core.Interfaces;
using RealPlazaChallenge.Infrastructure.Data;
using RealPlazaChallenge.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace RealPlazaChallenge.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ChallengeContext _context;

        public ProductRepository(ChallengeContext context)
        {
            _context = context;
        }

        public Task<int> AddProduct(Product pr)
        {
            tb_product tb_pro = new tb_product { 
                name = pr.Name,
                description = pr.Description,
                status = pr.Status,
                price = pr.Price,
                discount = pr.Discount,
                quantity = pr.Quantity,
                inserted_time = DateTime.Now,
                updated_time = DateTime.Now 
            };

            _context.products.Add(tb_pro);
            _context.SaveChanges();

            int newId = tb_pro.id;

            return Task.FromResult(newId);
        }

        public Task<int> UpdateProduct(Product pr)
        {
            tb_product tb_pro = new tb_product
            {
                id = pr.Id,
                name = pr.Name,
                description = pr.Description,
                status = pr.Status,
                price = pr.Price,
                discount = pr.Discount,
                quantity = pr.Quantity,
                inserted_time = DateTime.Now,
                updated_time = DateTime.Now
            };

            var dbEntry = _context.Entry(tb_pro);

            dbEntry.Property(x => x.id).IsModified = false;
            dbEntry.Property(x => x.inserted_time).IsModified = false;

            _context.products.Update(tb_pro);
            _context.SaveChanges();

            return Task.FromResult(0);
        }

        public Task<int> RemoveProduct(int id)
        {
            var product = _context.products.Find(id);
            if (product == null)
            {
                return Task.FromResult(1);
            }

            _context.products.Remove(product);
            _context.SaveChanges();

            return Task.FromResult(0);
        }

        public Task<Product> GetById(int id)
        {
            var product = _context.products.Find(id);

            if (product != null)
            {
                Product tb_pro = new Product
                {
                    Id = product.id,
                    Name = product.name,
                    Description = product.description,
                    Status = product.status,
                    Price = product.price,
                    Discount = product.discount,
                    Quantity = product.quantity,
                    Inserted_time = product.inserted_time,
                    Updated_time = product.updated_time
                };

                return Task.FromResult(tb_pro);
            }
            else
                return null;
        }

        public async Task<List<Product>> GetProducts()
        {
            List<Product> products = new List<Product>();

            var result = await Task.Run(() => _context.products.ToListAsync());

            foreach (var r in result)
            {
                products.Add(new Product
                {
                    Id = r.id,
                    Name = r.name,
                    Description = r.description,
                    Status = r.status,
                    Price = r.price,
                    Discount = r.discount,
                    Quantity = r.quantity,
                    Inserted_time = r.inserted_time,
                    Updated_time = r.updated_time
                });
            }

            return products;
        }

        public async Task<List<Product>> GetProductsSearch(string name)
        {
            List<Product> products = new List<Product>();
            var result = await Task.Run(() => _context.products.Where(x => x.name.Contains(name)).ToListAsync());

            foreach (var r in result)
            {
                products.Add(new Product
                {
                    Id = r.id,
                    Name = r.name,
                    Description = r.description,
                    Status = r.status,
                    Price = r.price,
                    Discount = r.discount,
                    Quantity = r.quantity,
                    Inserted_time = r.inserted_time,
                    Updated_time = r.updated_time
                });
            }

            return products;
        }
    }
}
