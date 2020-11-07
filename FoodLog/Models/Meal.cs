using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodLog.Models
{
    [FirestoreData]
    public class Meal
    {
        public int Id { get; set; }
        [FirestoreProperty]
        public string Date { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public List<Food> Foods { get; set; }

    }
}
