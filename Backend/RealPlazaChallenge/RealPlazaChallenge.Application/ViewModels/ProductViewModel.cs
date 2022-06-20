using RealPlazaChallenge.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealPlazaChallenge.Application.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(Product pr)
        {
            Id = pr.Id;
            Name = pr.Name;
            Description = pr.Description;
            Status = pr.Status;
            Price = pr.Price;
            Discount = pr.Discount;
            Quantity = pr.Quantity;
            Inserted_time = pr.Inserted_time;
            Updated_time = pr.Updated_time;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public DateTime Inserted_time { get; set; }
        public DateTime Updated_time { get; set; }
    }
}
