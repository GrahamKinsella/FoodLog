using FoodLog.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodLog.Contexts
{
    public class FoodContext: DbContext
    {
        public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=FoodLog.db");
    }
}
