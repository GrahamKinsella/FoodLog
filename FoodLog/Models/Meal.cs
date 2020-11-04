using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace FoodLog.Models
{
    [FirestoreData]
    public abstract class Meal : IMeal
    {
        public int Id { get; set; }
        public string date { get; set; }
        public string Name { get; set; }
        public List<Food> Foods { get; set; }

    }
}
