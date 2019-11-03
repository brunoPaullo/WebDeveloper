using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cibertec.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    } 
}
