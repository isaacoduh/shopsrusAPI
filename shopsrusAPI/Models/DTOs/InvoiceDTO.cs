using System;
namespace shopsrusAPI.Models.DTOs
{
    public class InvoiceDTO
    {
        public decimal Bill { get; set; }
        public Customer customer { get; set; }
        public Discount discountApplied { get; set; }
    }
}
