using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodLog.Models
{
    [FirestoreData]
    public class Food
    {
        public int Id { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public int Calories { get; set; }
        [FirestoreProperty]
        public int Carbohydrates { get; set; }
        [FirestoreProperty]
        public int Protein { get; set; }
        [FirestoreProperty]
        public int Fats { get; set; }

    }
}
