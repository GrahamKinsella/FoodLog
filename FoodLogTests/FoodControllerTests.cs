using FoodLog.Contexts;
using FoodLog.Models;
using FoodLog.Repositories;
using FoodLogTests.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FoodLogTests
{
    public class FoodControllerTests
    {
        private Mock<IFoodContext> _context;
        private FoodRepository _repo;
        [Fact]
        public void TestGetFood()
        {
            //TODO: Move Mock db setup to a base class
            FoodRequest foodRequest = new FoodRequest
            {
                Name = "Banana"
            };

            var foods = new List<Food>
            {
                new Food
                {
                    Id = 1,
                    Name = "Banana",
                    Calories = 100,
                    Carbohydrates = 10,
                    Fats = 1,
                    Protein = 3

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Food>>();
            mockSet.As<IQueryable<Food>>().Setup(m => m.Provider).Returns(foods.Provider);
            mockSet.As<IQueryable<Food>>().Setup(m => m.Expression).Returns(foods.Expression);
            mockSet.As<IQueryable<Food>>().Setup(m => m.ElementType).Returns(foods.ElementType);
            mockSet.As<IQueryable<Food>>().Setup(m => m.GetEnumerator()).Returns(foods.GetEnumerator());

            _context = new Mock<IFoodContext>();
            _context.Setup(c => c.Foods).Returns(mockSet.Object);
            _repo = new FoodRepository(_context.Object);

            Assert.Single(_repo.GetFoods(foodRequest));

        }

        [Fact]
        public void TestAddFood()
        {
            //TODO: Move Mock db setup to a base class
            Food food = new Food
            {
                Name = "Apple",
                Calories = 110,
                Carbohydrates = 15,
                Fats = 11,
                Protein = 10
            };

            var foods = new List<Food>
            {
                new Food
                {
                    Id = 1,
                    Name = "Banana",
                    Calories = 100,
                    Carbohydrates = 10,
                    Fats = 1,
                    Protein = 3

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Food>>();
            mockSet.As<IQueryable<Food>>().Setup(m => m.Provider).Returns(foods.Provider);
            mockSet.As<IQueryable<Food>>().Setup(m => m.Expression).Returns(foods.Expression);
            mockSet.As<IQueryable<Food>>().Setup(m => m.ElementType).Returns(foods.ElementType);
            mockSet.As<IQueryable<Food>>().Setup(m => m.GetEnumerator()).Returns(foods.GetEnumerator());

            _context = new Mock<IFoodContext>();
            _context.Setup(c => c.Foods).Returns(mockSet.Object);
            _repo = new FoodRepository(_context.Object);

            _repo.CreateFood(food);
           //Write Assertion
        }

        [Fact]
        public void TestDeleteFood()
        {
            //TODO: Move Mock db setup to a base class
            FoodRequest food = new FoodRequest
            {
                Id = 1
            };

            var foods = new List<Food>
            {
                new Food
                {
                    Id = 1,
                    Name = "Banana",
                    Calories = 100,
                    Carbohydrates = 10,
                    Fats = 1,
                    Protein = 3

                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Food>>();
            mockSet.As<IQueryable<Food>>().Setup(m => m.Provider).Returns(foods.Provider);
            mockSet.As<IQueryable<Food>>().Setup(m => m.Expression).Returns(foods.Expression);
            mockSet.As<IQueryable<Food>>().Setup(m => m.ElementType).Returns(foods.ElementType);
            mockSet.As<IQueryable<Food>>().Setup(m => m.GetEnumerator()).Returns(foods.GetEnumerator());

            _context = new Mock<IFoodContext>();
            _context.Setup(c => c.Foods).Returns(mockSet.Object);
            _repo = new FoodRepository(_context.Object);

            _repo.Delete(food);
            //Write assertion

        }
    }
}
