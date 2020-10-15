using System.Collections.Generic;
using System.Linq;
using FoodLog.Contexts;
using FoodLog.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoodLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodContext _foodContext;

        public FoodController(FoodContext fc)
        {
            _foodContext = fc;
        }

        [HttpPost]
        [Route("GetFood")]
        public List<Food> GetFoodByName([FromBody] FoodRequest food)
        {
            return _foodContext.GetFoods(food);
        }

        [HttpPost]
        [Route("CreateFood")]
        public void CreateFood([FromBody] Food food)
        {
            _foodContext.CreateFood(food);
        }

        [HttpPost]
        [Route("DeleteFood")]
        public void Delete([FromBody] FoodRequest foodRequest)
        {
            _foodContext.Delete(foodRequest);
        }
    }
}
