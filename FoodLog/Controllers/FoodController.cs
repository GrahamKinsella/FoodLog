using System.Collections.Generic;
using System.Linq;
using FoodLog.Contexts;
using FoodLog.Models;
using FoodLog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FoodLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _foodRepo;


        public FoodController(IFoodRepository fr)
        {
            _foodRepo = fr;

        }
        //TODO: receive a list and then get each food in lists
        [HttpPost]
        [Route("GetFood")]
        public List<Food> GetFoodByName([FromBody] FoodRequest foodRequest)
        {
            return _foodRepo.GetFoods(foodRequest);
        }

        [HttpGet]
        [Route("GetAllFood")]
        public List<Food> GetAllFoods()
        {
            return _foodRepo.GetAllFoods();
        }

        [HttpPut]
        [Route("UpdateFood")]
        public void UpdateFood([FromBody] FoodRequest foodRequest)
        {
            _foodRepo.Update(foodRequest);
        }

        [HttpPost]
        [Route("CreateFood")]
        public void CreateFood([FromBody] FoodRequest foodRequest)
        {
            var food = new Food
            {
                Name = foodRequest.Name,
                Calories = foodRequest.Calories,
                Carbohydrates = foodRequest.Carbohydrates,
                Protein = foodRequest.Protein,
                Fats = foodRequest.Fats
            };
            
            _foodRepo.CreateFood(food);
        }

        [HttpPost]
        [Route("DeleteFood")]
        public void Delete([FromBody] FoodRequest foodRequest)
        {
            _foodRepo.Delete(foodRequest);
        }
    }
}
