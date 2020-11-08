using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodLog.DataAccess;
using FoodLog.Interfaces;
using FoodLog.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace BlazorWithFirestore.Server.DataAccess
{
    public class FoodDataAccessLayer : BaseDataAccessLayer, IFoodDataAccessLayer
    {
        const string CollectionName = "Foods";

        public FoodDataAccessLayer(FirestoreDb firestore) : base(firestore)
        {
        }

        public void AddFood(Food Food)
        {
            throw new NotImplementedException();
        }

        public void DeleteFood(Food Food)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Food>> GetAllFoods(Food foodRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<Food> GetFood(Food foodRequest)
        {
            Food retrievedFood = null;
            QuerySnapshot FoodQuerySnapshot = await GetSnapshot(foodRequest);

            if (FoodQuerySnapshot.Documents.Count != 0)
            {
                //this should be get meal
                Dictionary<string, object> food = FoodQuerySnapshot.Documents.First().ToDictionary();
                string json = JsonConvert.SerializeObject(food);
                retrievedFood = JsonConvert.DeserializeObject<Food>(json);
                return retrievedFood;
            }

            return retrievedFood;
        }

        public void UpdateFood(Food Food)
        {
            throw new NotImplementedException();
        }

        private async Task<QuerySnapshot> GetSnapshot(Food foodRequest)
        {
            Query query = _firestore.Collection(CollectionName).WhereEqualTo("Name", foodRequest.Name);
            QuerySnapshot FoodQuerySnapshot = await query.GetSnapshotAsync();
            return FoodQuerySnapshot;
        }
    }
}
