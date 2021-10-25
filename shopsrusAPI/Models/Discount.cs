using System;
using System.ComponentModel.DataAnnotations;

namespace shopsrusAPI.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
