using InventoryMgtSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryMgtSystemAPI.DatabaseContexts
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        :base(options)
        {
            
        }
        public DbSet<InventoryModel> InventoryModel { get; set; }
    }
}