using System;
namespace shopsrusAPI.Models.DTOs
{
    public class CreateInvoiceDTO
    {
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
    }
}
