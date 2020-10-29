using FoodLog.Contexts;
using FoodLog.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodLog.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private IFoodContext _context;

        public FoodRepository(IFoodContext foodContext)
        {
            _context = foodContext;
        }

        public List<Food> GetAllFoods()
        {
            return _context.Foods.ToList();
        }

        public List<Food> GetFoodByName(FoodRequest food)
        {
            return _context.Foods.Where(x => x.Name.Contains(food.Name)).ToList();
        }

        public Food GetFoodById(int id)
        {
            return _context.Foods.Single(x => x.Id == id);
        }

        public void CreateFood(Food food)
        {
            _context.AddToContext(food);
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

        public void Update(FoodRequest foodRequest)
        {
            Food foodToUpdate = _context.Foods.Single(x => x.Id == foodRequest.Id);
            if (foodToUpdate != null)
            {
                //TODO: Better way to do this using linq?
                foodToUpdate.Name = foodRequest.Name;
                foodToUpdate.Calories = foodRequest.Calories;
                foodToUpdate.Carbohydrates = foodRequest.Carbohydrates;
                foodToUpdate.Protein = foodRequest.Protein;
                foodToUpdate.Fats = foodRequest.Fats;

                _context.Foods.Update(foodToUpdate);
                _context.SaveChangesToContext();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}