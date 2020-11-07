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
        void DeleteFoodFromMeal(Food food, string date, string mealName);
        void UpdateMeal(Meal mealRequest);
    }
}
