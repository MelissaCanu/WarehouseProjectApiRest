using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseProjectApiRest.Models;

namespace WarehouseProjectApiRest.Services
{
    public interface IWarehouseService
    {
        IEnumerable<ProductBatch> GetAllBatches();
        void AddBatch(ProductBatch batch);
        void RemoveProduct(int productId, int quantity);
    }

    public class WarehouseService : IWarehouseService
    {
        private readonly List<ProductBatch> _batches = new List<ProductBatch>();
        private const double MaxWarehouseSize = 1000.0;

        public IEnumerable<ProductBatch> GetAllBatches()
        {
            return _batches;
        }

        public void AddBatch(ProductBatch batch)
        {
            double currentSize = _batches.Sum(b => b.Product.Size * b.Quantity);
            if (currentSize + (batch.Product.Size * batch.Quantity) > MaxWarehouseSize)
            {
                throw new InvalidOperationException("Non c'è abbastanza spazio nel magazzino.");
            }
            _batches.Add(batch);
        }

        public void RemoveProduct(int productId, int quantity)
        {
            var batch = _batches.FirstOrDefault(b => b.Product.Id == productId);
            if (batch == null || batch.Quantity < quantity)
            {
                throw new InvalidOperationException("Quantità non disponibile in magazzino.");
            }
            batch.Quantity -= quantity;
            if (batch.Quantity == 0)
            {
                _batches.Remove(batch);
            }
        }
    }
}
