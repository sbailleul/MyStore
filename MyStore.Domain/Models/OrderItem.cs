using System.ComponentModel.DataAnnotations.Schema;
using MyStore.Domain.Framework;

namespace MyStore.Domain.Models
{
    public class OrderItem : Entity
    {
        public Order Order { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }

        public decimal Price { get; set; }

        public Product Product { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
