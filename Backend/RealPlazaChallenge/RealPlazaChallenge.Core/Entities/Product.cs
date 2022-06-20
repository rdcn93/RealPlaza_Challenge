using System;

namespace RealPlazaChallenge.Core.Entities
{
    public class Product
    {
        //public Product(int id, string name, string description, bool status, decimal price, decimal discount, int quantity, DateTime inserted, DateTime updated)
        //{
        //    Id = Id;
        //    Name = name;
        //    Description = description;
        //    Status = status;
        //    Price = price;
        //    Discount = discount;
        //    Quantity = quantity;
        //    Inserted_time = inserted;
        //    Updated_time = updated;
        //}

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
