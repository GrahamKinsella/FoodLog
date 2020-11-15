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

        public FoodController(IFoodDataAccessLayer fdl)
        {
            _fdl = fdl;
        }
        //TODO: receive a list and then get each food in lists
        [HttpPost]
        [Route("GetListOfFoodsByName")]
        public List<Food> GetListOfFoodsByName([FromBody] Food foodRequest)
        {
            return _fdl.GetFoodsMatchingName(foodRequest).Result;
           
        }

        [HttpPost]
        [Route("GetFood")]
        public Food GetFood([FromBody] Food foodRequest)
        {
            return _fdl.GetFood(foodRequest).Result;
        }

        [HttpGet]
        [Route("RecentlyAddedFood")]
        public List<Food> GetRecentFoods()
        {
            //get food by date
            return _fdl.GetRecentlyAddedFoods().Result;
        }

        [HttpPut]
        [Route("UpdateFood")]
        public void UpdateFood([FromBody] Food foodRequest)
        {
            _fdl.UpdateFood(foodRequest);
        }

        [HttpPost]
        [Route("CreateFood")]
        public void CreateFood([FromBody] Food food)
        {
            //implement
            _fdl.AddFood(food);
        }

        [HttpPost]
        [Route("DeleteFood")]
        public void Delete([FromBody] FoodRequest foodRequest)
        {
            //implements

        }
    }
}
