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
    public class MealDataAccessLayer : BaseDataAccessLayer, IMealDataAccessLayer
    {
        public MealDataAccessLayer(FirestoreDb firestore) : base(firestore)
        {
        }

        public async void AddMeal(Meal Meal)
        {
            try
            {
                CollectionReference colRef = _firestore.Collection("Meals");
                await colRef.AddAsync(Meal);
            }
            catch
            {
                throw;
            }
        }

        public async void UpdateMeal(Meal mealRequest)
        {
            try
            {
                var retrievedMeal = GetMeal(mealRequest);

                if (retrievedMeal != null)
                {
                    QuerySnapshot MealQuerySnapshot = await GetSnapshot(mealRequest);
                    DocumentReference Docref = MealQuerySnapshot.Documents.First().Reference;
                    await Docref.SetAsync(retrievedMeal, SetOptions.Overwrite);
                }
                else
                {
                    AddMeal(mealRequest);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Update meal failed: Exception {e}");
            }
        }

        public async Task<Meal> GetMeal(Meal mealRequest)
        {
            Meal retrievedMeal = null;
            QuerySnapshot MealQuerySnapshot = await GetSnapshot(mealRequest);

            if (MealQuerySnapshot.Documents.Count != 0)
            {
                //this should be get meal
                Dictionary<string, object> meal = MealQuerySnapshot.Documents.First().ToDictionary();
                string json = JsonConvert.SerializeObject(meal);
                retrievedMeal = JsonConvert.DeserializeObject<Meal>(json);
                return retrievedMeal;
            }

            return retrievedMeal;
        }

        private async Task<QuerySnapshot> GetSnapshot(Meal mealRequest)
        {
            Query query = _firestore.Collection("Meals").WhereEqualTo("Date", mealRequest.Date).WhereEqualTo("Name", mealRequest.Name);
            QuerySnapshot MealQuerySnapshot = await query.GetSnapshotAsync();
            return MealQuerySnapshot;
        }
    }
}
