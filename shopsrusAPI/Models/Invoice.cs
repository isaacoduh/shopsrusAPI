using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopsrusAPI.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Bill { get; set; }
        public decimal Discount { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
