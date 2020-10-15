using FoodLog.Contexts;
using FoodLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodLog.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private IFoodContext _context;

        public FoodRepository(IFoodContext foodContext)
        {
            _context = foodContext;
        }

        public List<Food> GetFoods(FoodRequest food)
        {
            return _context.Foods.Where(x => x.Name.Contains(food.Name)).ToList();
        }

        public void CreateFood(Food food)
        {
            _context.AddToContext(new Food
            {
                Name = food.Name,
                Calories = food.Calories,
                Carbohydrates = food.Carbohydrates,
                Protein = food.Protein,
                Fats = food.Fats
            });

            _context.SaveChangesToContext();
        }

        public void Delete(FoodRequest foodRequest)
        {
            Food foodToDelete = _context.Foods.Single(x => x.Id == foodRequest.Id);
            if (foodToDelete != null)
            {
                _context.Foods.Remove(foodToDelete);
                _context.SaveChangesToContext();
            }
        }
    }
}