using FoodLog.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FoodLog.Contexts
{
    public class FoodContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=FoodLog.db");

        public List<Food> GetFoods(FoodRequest food)
        {
            return Foods.Where(x => x.Name.Contains(food.Name)).ToList();
        }

        public void CreateFood(Food food)
        {
            Add(new Food
            {
                Name = food.Name,
                Calories = food.Calories,
                Carbohydrates = food.Carbohydrates,
                Protein = food.Protein,
                Fats = food.Fats
            });

            SaveChanges();
        }

        public void Delete(FoodRequest foodRequest)
        {
            Food foodToDelete = Foods.Single(x => x.Id == foodRequest.Id);
            if (foodToDelete != null)
            {
                Foods.Remove(foodToDelete);
                SaveChanges();
            }
        }
    }
}
