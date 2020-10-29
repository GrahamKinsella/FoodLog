using FoodLog.Models;
using System.Collections.Generic;

namespace FoodLog.Repositories
{
    public interface IFoodRepository
    {
        void CreateFood(Food food);
        void Delete(FoodRequest foodRequest);
        List<Food> GetFoodByName(FoodRequest food);
        Food GetFoodById(int id);


        List<Food> GetAllFoods();
        void Update(FoodRequest foodRequest);
    }
}