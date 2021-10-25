using System;
using System.ComponentModel.DataAnnotations;

namespace shopsrusAPI.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
    }
}
