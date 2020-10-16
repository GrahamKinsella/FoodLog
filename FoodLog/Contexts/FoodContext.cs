using FoodLog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FoodLog.Contexts
{
    public class FoodContext : DbContext, IFoodContext
    {
        public DbSet<Food> Foods { get; set; }

        public FoodContext(DbContextOptions<FoodContext> options)
             : base(options)
        { }


        public void SaveChangesToContext()
        {
            base.SaveChanges();
        }

        public void AddToContext(Food food)
        {
            base.Add(food);
        }
    }
}
