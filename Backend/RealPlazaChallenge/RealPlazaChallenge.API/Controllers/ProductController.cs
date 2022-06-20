using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RealPlazaChallenge.Application.InputModel;
using RealPlazaChallenge.Application.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealPlazaChallenge.API.Controllers
{

    [Route("api/product")]
    [EnableCors("permit")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productService.GetProducts();

                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductModel productInputModel)
        {
            var id = await _productService.AddProduct(productInputModel);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetProductsSearch(string name)
        {
            try
            {
                var products = await _productService.GetProductsSearch(name);

                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, internal Server Error");
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ProductModel productInputModel)
        {
            if (ModelState.IsValid)
            {
                productInputModel.Updated_time = DateTime.Now;

                _productService.UpdateProduct(productInputModel);

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var result = await _productService.RemoveProduct(id);

            if (result == 0)
                return Ok();
            else
                return NotFound();
        }

        
    }
}
