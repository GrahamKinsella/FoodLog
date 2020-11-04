using Google.Cloud.Firestore;
using System.Collections.Generic;

namespace FoodLog.Models
{
    public interface IMeal
    {
        int Id { get; set; }
        [FirestoreProperty]
        string date { get; set; }
        [FirestoreProperty]
        List<Food> Foods { get; set; }
        [FirestoreProperty]
        string Name { get; set; }
    }
}