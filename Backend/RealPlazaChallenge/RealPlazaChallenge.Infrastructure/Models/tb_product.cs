using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealPlazaChallenge.Infrastructure.Models
{
    [Table("tb_product")]
    public class tb_product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public int quantity { get; set; }
        public DateTime inserted_time { get; set; }
        public DateTime updated_time { get; set; }
    }
}
