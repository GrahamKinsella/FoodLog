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
        void UpdateMeal(Meal mealRequest);
    }
}
