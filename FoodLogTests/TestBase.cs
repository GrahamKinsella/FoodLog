using FoodLog.Contexts;
using FoodLog.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodLogTests
{
    public class TestBase
    {
        protected DbContextOptions<FoodContext> ContextOptions { get; }
        public TestBase()
        {
           ContextOptions = new DbContextOptionsBuilder<FoodContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
        }

    }
}
