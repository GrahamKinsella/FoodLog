using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodLog.Interfaces;
using FoodLog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IFoodDataAccessLayer _fdl;
        private IMealDataAccessLayer _mdl;

        public MealController(IFoodDataAccessLayer fdl, IMealDataAccessLayer mdl)
        {
            _fdl = fdl;
            _mdl = mdl;
        }

        [HttpPost]
        [Route("UpdateMeal")]
        public void CreateFood([FromBody] List<Food> foods)
        {
            _mdl.UpdateMeal(foods);
        }
    }
}