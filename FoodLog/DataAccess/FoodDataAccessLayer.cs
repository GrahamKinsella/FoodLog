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

        public FoodDataAccessLayer(FirestoreDb firestore) : base(firestore)
        {
        }
        public async Task<List<Food>> GetAllFoods()
        {
            try
            {
                Query FoodQuery = _firestore.Collection("Foods");
                QuerySnapshot FoodQuerySnapshot = await FoodQuery.GetSnapshotAsync();
                List<Food> lstFood = new List<Food>();

                foreach (DocumentSnapshot documentSnapshot in FoodQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> food = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(food);
                        Food newFood = JsonConvert.DeserializeObject<Food>(json);
                        newFood.Id = int.Parse(documentSnapshot.Id);
                        lstFood.Add(newFood);
                    }
                }
                return lstFood;
            }
            catch
            {
                throw;
            }
        }

        public async void AddFood(Food Food)
        {
            try
            {
                CollectionReference colRef = _firestore.Collection("Foods");
                await colRef.AddAsync(Food);
            }
            catch
            {
                throw;
            }
        }
        public async void UpdateFood(Food Food)
        {
            try
            {
                DocumentReference empRef = _firestore.Collection("Foods").Document(Food.Id.ToString());
                await empRef.SetAsync(Food, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Food> GetFoodData(string id)
        {
            try
            {
                DocumentReference docRef = _firestore.Collection("Foods").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Food emp = snapshot.ConvertTo<Food>();
                    emp.Id = int.Parse(snapshot.Id);
                    return emp;
                }
                else
                {
                    return new Food();
                }
            }
            catch
            {
                throw;
            }
        }
        public async void DeleteFood(string id)
        {
            try
            {
                DocumentReference empRef = _firestore.Collection("Foods").Document(id);
                await empRef.DeleteAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<Food>> GetFoodData()
        {
            try
            {
                Query citiesQuery = _firestore.Collection("cities");
                QuerySnapshot citiesQuerySnapshot = await citiesQuery.GetSnapshotAsync();
                List<Food> lstFoods = new List<Food>();

                foreach (DocumentSnapshot documentSnapshot in citiesQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> city = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(city);
                        Food newFood = JsonConvert.DeserializeObject<Food>(json);
                        lstFoods.Add(newFood);
                    }
                }
                return lstFoods;
            }
            catch
            {
                throw;
            }
        }
    }
}
