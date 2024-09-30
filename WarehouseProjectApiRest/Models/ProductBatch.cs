namespace WarehouseProjectApiRest.Models
   
{
    public class ProductBatch
    {
        public int Id { get; set; }
        public Product Product { get; set; } // refers to the Product class
        public int Quantity { get; set; }
    }
}
