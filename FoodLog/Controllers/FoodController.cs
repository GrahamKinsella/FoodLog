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

        [HttpPost]
        [Route("GetFood")]
        public List<Food> GetFoodByName([FromBody] FoodRequest food)
        {
            return _foodRepo.GetFoods(food);
        }

        [HttpPost]
        [Route("CreateFood")]
        public void CreateFood([FromBody] Food food)
        {
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
