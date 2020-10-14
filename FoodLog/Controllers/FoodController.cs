using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FoodLog.Contexts;
using FoodLog.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoodLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        
        private readonly FoodContext _foodContext = new FoodContext();

        [HttpPost]
        [Route("GetFood")]
        public List<Food> GetFoodByName([FromBody] FoodRequest food)
        {
            return _foodContext.Foods.Where(x => x.Name.Contains(food.Name)).ToList();
        }

        [HttpPost]
        [Route("CreateFood")]
        public void CreateFood([FromBody] Food food)
        {
            _foodContext.Add(new Food
            {
                Name = food.Name,
                Calories = food.Calories,
                Carbohydrates = food.Carbohydrates,
                Protein = food.Protein,
                Fats = food.Fats
            });
            _foodContext.SaveChanges();
        }

        [HttpPost]
        [Route("DeleteFood")]
        public void Delete([FromBody] FoodRequest foodRequest)
        {
            Food foodToDelete = _foodContext.Foods.Single(x => x.Id == foodRequest.Id);
            if(foodToDelete != null)
            {
                _foodContext.Foods.Remove(foodToDelete);
                _foodContext.SaveChanges();
            }
        }
    }
}
