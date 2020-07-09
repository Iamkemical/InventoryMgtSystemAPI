using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CreateInventory(InventoryModel model)
        {
            if(model is null) throw new ArgumentNullException(message: "You've not entered any valid details", null);

            _inventoryDbContext.InventoryModel.Add(model);
            _inventoryDbContext.SaveChanges();
        }

        public void DeleteInventory(int id)
        {
            var model = _inventoryDbContext.InventoryModel.Find(id);
            if(model is null)
            {
                throw new ArgumentNullException(message: "The inventory with this id doesn't exist", null);
            }
            _inventoryDbContext.InventoryModel.Remove(model);
            _inventoryDbContext.SaveChanges();
        }

        public IEnumerable<InventoryModel> GetInventories()
        {
            return _inventoryDbContext.InventoryModel.ToList();
        }

        public InventoryModel GetInventoryById(int id)
        {
            var inventory = _inventoryDbContext.InventoryModel.FirstOrDefault(opt=> opt.InventoryId == id);

            if(inventory is null) throw new ArgumentNullException(message: "The inventory you're in search of is not in the database or has been deleted", null);

            return inventory;
        }

        public bool SaveChanges()
        {
            return (_inventoryDbContext.SaveChanges() >0);
        }

        public InventoryModel UpdateInventory(int id, InventoryModel model)
        {
            var inventory = _inventoryDbContext.InventoryModel.Find(id);
            if(model is null)
            {
                throw new ArgumentNullException(message:"The inventory you're in search of does not exist in the database or has been deleted", null);
            }
            if(inventory != model)
            {
                inventory.ItemName = model.ItemName;
            }
            if(inventory != model)
            {
                inventory.AmountPerItem = model.AmountPerItem;
            }
            if(inventory != model)
            {
                inventory.DatePurchased = inventory.DatePurchased;
            }
            if(inventory != model)
            {
                inventory.StockQty = model.StockQty;
            }

            return inventory;
        }
    }
}