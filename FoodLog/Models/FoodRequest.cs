using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodLog.Models
{
    
    public class FoodRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
