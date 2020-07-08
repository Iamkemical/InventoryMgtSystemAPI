using System.Collections.Generic;
using InventoryMgtSystemAPI.Models;

namespace InventoryMgtSystemAPI.Repositories
{
    public interface IInventoryRepo 
    {
        IEnumerable<InventoryModel> GetInventories();
        InventoryModel GetInventoryById(int id);
    }
}