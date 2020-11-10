using FoodLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodLog.Interfaces
{
    public interface IFoodDataAccessLayer
    {
        void AddFood(Food foodRequest);
        void DeleteFood(Food foodRequest);
        Task<List<Food>> GetFoodsMatchingName(Food foodRequest);
        void UpdateFood(Food foodRequest);
        Task<Food> GetFood(Food foodRequest);
    }
}
