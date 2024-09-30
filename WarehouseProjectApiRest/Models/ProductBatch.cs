namespace WarehouseProjectApiRest.Models
{
    public class ProductBatch
    {
        public int Id { get; set; }
        public int Product { get; set; } // Refers to Product.Id
        public int Quantity { get; set; }
    }
}
