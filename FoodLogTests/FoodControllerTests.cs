using FoodLog.Contexts;
using FoodLog.Controllers;
using FoodLog.Models;
using FoodLog.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FoodLogTests
{
    public class FoodControllerTests : TestBase
    {
        [Fact]
        public void TestCreateFood()
        {
            using (var context = new FoodContext(ContextOptions))
            {
                var repo = new FoodRepository(context);
                repo.CreateFood(new Food { Calories = 300, Carbohydrates = 34, Fats = 33, Name = "Chocolate", Protein = 5 });
                repo.Dispose();
            }
        }

        [Fact]
        public void TestGetFood()
        {
            using (var context = new FoodContext(ContextOptions))
            {
                var repo = new FoodRepository(context);
                repo.CreateFood(new Food { Calories = 300, Carbohydrates = 34, Fats = 33, Name = "Chocolate", Protein = 5 });
                Assert.Single(repo.GetFoods(new FoodRequest { Name = "Chocolate" }));
                repo.Dispose();
            }
        }

        [Fact]
        public void TestDeleteFood()
        {
            using (var context = new FoodContext(ContextOptions))
            {
                var repo = new FoodRepository(context);
                repo.CreateFood(new Food { Calories = 300, Carbohydrates = 34, Fats = 33, Name = "Chocolate", Protein = 5 });
                repo.CreateFood(new Food { Calories = 200, Carbohydrates = 22, Fats = 11, Name = "Orange", Protein = 13 });
                repo.Delete(new FoodRequest { Name = "Orange", Id = 2 });

                Assert.Single(repo.GetAllFoods());
                repo.Dispose();
            }
        }


        [Fact]
        public void TestGetAllFood()
        {
            using (var context = new FoodContext(ContextOptions))
            {
                var repo = new FoodRepository(context);
                repo.CreateFood(new Food { Calories = 300, Carbohydrates = 34, Fats = 33, Name = "Chocolate", Protein = 5 });

                Assert.Single(repo.GetAllFoods());
                repo.Dispose();
            }
        }
    }
}
