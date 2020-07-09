using System.Collections.Generic;
using InventoryMgtSystemAPI.Models;

namespace InventoryMgtSystemAPI.Repositories
{
    public interface IInventoryRepo 
    {
        IEnumerable<InventoryModel> GetInventories();
        InventoryModel GetInventoryById(int id);
        void CreateInventory(InventoryModel model);
        InventoryModel UpdateInventory(int id, InventoryModel model);
        void DeleteInventory(int id);
        bool SaveChanges();
    }
}