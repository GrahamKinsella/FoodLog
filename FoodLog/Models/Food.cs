﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodLog.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Protein { get; set; }
        public int Fats { get; set; }

    }
}
