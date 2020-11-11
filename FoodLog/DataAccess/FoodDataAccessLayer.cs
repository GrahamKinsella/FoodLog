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

        public async void AddFood(Food foodRequest)
        {
            try
            {
                CollectionReference colRef = _firestore.Collection(CollectionName);
                await colRef.AddAsync(foodRequest);
            }
            catch
            {
                throw;
            }
        }

        public void DeleteFood(Food foodRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Food>> GetFoodsMatchingName(Food foodRequest)
        {
            List<Food> allFood = new List<Food>();
            QuerySnapshot FoodQuerySnapshot = await GetSnapshotAllFood();
            if (FoodQuerySnapshot.Documents.Count != 0)
            {
                foreach (var doc in FoodQuerySnapshot.Documents)
                {
                    allFood.Add(SerializeFood(doc));
                }
                return allFood.Where(f => f.Name.ToLower().Contains(foodRequest.Name.ToLower())).ToList();
            }
            return allFood;
        }

        public async Task<Food> GetFood(Food foodRequest)
        {
            Food retrievedFood = null;
            QuerySnapshot FoodQuerySnapshot = await GetSnapshotByName(foodRequest);

            if (FoodQuerySnapshot.Documents.Count != 0)
            {
                var doc = FoodQuerySnapshot.Documents.First();
                retrievedFood = SerializeFood(doc);
                return retrievedFood;
            }

            return retrievedFood;
        }

        public Food SerializeFood(DocumentSnapshot doc)
        {
            Dictionary<string, object> food = doc.ToDictionary();
            string json = JsonConvert.SerializeObject(food);
            return JsonConvert.DeserializeObject<Food>(json);
        }

        public async void UpdateFood(Food foodRequest)
        {
            try
            {
                var retrievedFood = GetFood(foodRequest);

                if (retrievedFood != null)
                {
                    QuerySnapshot FoodQuerySnapshot = await GetSnapshotByName(foodRequest);
                    DocumentReference Docref = FoodQuerySnapshot.Documents.First().Reference;
                    await Docref.SetAsync(foodRequest, SetOptions.Overwrite);
                }
                else
                {
                    AddFood(foodRequest);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Update food failed: Exception {e}");
            }
        }

        private async Task<QuerySnapshot> GetSnapshotByName(Food foodRequest)
        {
            Query query = _firestore.Collection(CollectionName).WhereEqualTo("Name", foodRequest.Name);
            QuerySnapshot FoodQuerySnapshot = await query.GetSnapshotAsync();
            return FoodQuerySnapshot;
        }

        private async Task<QuerySnapshot> GetSnapshotAllFood()
        {
            Query query = _firestore.Collection(CollectionName);
            QuerySnapshot FoodQuerySnapshot = await query.GetSnapshotAsync();
            return FoodQuerySnapshot;
        }
    }
}
