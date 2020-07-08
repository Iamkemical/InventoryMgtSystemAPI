using System.Collections.Generic;
using InventoryMgtSystemAPI.DatabaseContexts;
using InventoryMgtSystemAPI.Models;
using InventoryMgtSystemAPI.Repositories;

namespace InventoryMgtSystemAPI.Services
{
    public class InventoryService : IInventoryRepo
    {
        private readonly InventoryDbContext _inventoryDbContext;

        public InventoryService(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }
        public IEnumerable<InventoryModel> GetInventories()
        {
            throw new System.NotImplementedException();
        }

        public InventoryModel GetInventoryById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}