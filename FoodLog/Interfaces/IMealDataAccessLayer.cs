using FoodLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodLog.Interfaces
{
    public interface IMealDataAccessLayer
    {
        void AddMeal(Meal Meal);
        void DeleteMeal(string id);
        Task<List<Meal>> GetAllMeals();
        Task<List<Food>> GetFoodData();
        Task<Meal> GetMealData(string id);
        void UpdateMeal(List<Food> foods);
    }
}
