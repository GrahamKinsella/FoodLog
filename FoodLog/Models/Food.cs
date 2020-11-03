using Google.Cloud.Firestore;

namespace FoodLog.Models
{
    [FirestoreData]
    public abstract class Food : IFood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbohydrates { get; set; }
        public int Protein { get; set; }
        public int Fats { get; set; }

    }
}
