using FoodLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodLog.Interfaces
{
    public interface IFoodDataAccessLayer
    {
        void AddFood(Food Food);
        void DeleteFood(string id);
        Task<List<Food>> GetAllFoods();
        Task<Food> GetFoodData(string id);
        Task<List<Food>> GetFoodData();
        void UpdateFood(Food Food);
    }
}
