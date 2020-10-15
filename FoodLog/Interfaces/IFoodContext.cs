using FoodLog.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;
using System.Collections.Generic;

namespace FoodLog.Contexts
{
    public interface IFoodContext
    {
        DbSet<Food> Foods { get; set; }

        public void SaveChangesToContext();
        public void AddToContext(Food food);

    }
}