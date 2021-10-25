using System;
namespace shopsrusAPI.Models.DTOs
{
    public class CreateInvoiceDTO
    {
        public int customerId { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
    }
}
