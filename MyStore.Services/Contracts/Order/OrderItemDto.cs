using MyStore.Services.Contracts.Product;
using MyStore.Services.Framework;

namespace MyStore.Services.Contracts.Order
{
    public class OrderItemDto : Dto
    {
        public decimal Price { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
