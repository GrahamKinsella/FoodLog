using System;
using System.Collections.Generic;
using BlazorWithFirestore.Server.DataAccess;
using FoodLog.Interfaces;
using FoodLog.Models;
using Google.Cloud.Firestore;
using Google.Type;
using Microsoft.AspNetCore.Mvc;

namespace FoodLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private IFoodDataAccessLayer _fdl;
        private IMealDataAccessLayer _mdl;

        public FoodController(IFoodDataAccessLayer fdl, IMealDataAccessLayer mdl)
        {
            _fdl = fdl;
            _mdl = mdl;
        }
        //TODO: receive a list and then get each food in lists
        [HttpPost]
        [Route("GetFoodByName")]
        public List<Food> GetFoodByName([FromBody] FoodRequest foodRequest)
        {
            return new List<Food>();
        }

        [HttpPost]
        [Route("GetFoodById")]
        public Food GetFoodById([FromBody] int id)
        {
            return new Food();
        }

        [HttpGet]
        [Route("GetAllFood")]
        public List<Food> GetAllFoodsAsync()
        {
            return new List<Food>();
        }

        [HttpPut]
        [Route("UpdateFood")]
        public void UpdateFood([FromBody] FoodRequest foodRequest)
        {
        }

        [HttpPost]
        [Route("CreateFood")]
        public void CreateFood([FromBody] Food food)
        {
            _fdl.AddFood(food);
        }

        [HttpPost]
        [Route("DeleteFood")]
        public void Delete([FromBody] FoodRequest foodRequest)
        {
        }
    }
}
