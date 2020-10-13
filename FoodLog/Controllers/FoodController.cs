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
        
        private readonly FoodContext _foodContext = new FoodContext();

        // GET: api/Food
        [HttpGet]
        public Food Get()
        {
            return _foodContext.Foods.First();
        }

        // GET: api/Food/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Food
        [HttpPost]
        public void Post([FromBody] Food food)
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

        // PUT: api/Food/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
