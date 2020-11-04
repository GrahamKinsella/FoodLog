using Google.Cloud.Firestore;

namespace FoodLog.Models
{
    public interface IFood
    {
        int Id { get; set; }
        [FirestoreProperty]
        int Calories { get; set; }
        [FirestoreProperty]
        int Carbohydrates { get; set; }
        [FirestoreProperty]
        int Fats { get; set; }
        [FirestoreProperty]
        string Name { get; set; }
        [FirestoreProperty]
        int Protein { get; set; }
    }
}