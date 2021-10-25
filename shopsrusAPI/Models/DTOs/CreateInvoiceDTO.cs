using System;
namespace shopsrusAPI.Models.DTOs
{
    public class CreateInvoiceDTO
    {
        public int customerId { get; set; }
        public decimal Amount { get; set; }
        public string discountCode { get; set; }
    }
}
