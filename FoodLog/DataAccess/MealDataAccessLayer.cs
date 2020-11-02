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
    public class MealDataAccessLayer: BaseDataAccessLayer, IMealDataAccessLayer
    {
        public MealDataAccessLayer(FirestoreDb firestore) : base(firestore)
        {
        }
        public async Task<List<Meal>> GetAllMeals()
        {
            try
            {
                Query MealQuery = _firestore.Collection("Meals");
                QuerySnapshot MealQuerySnapshot = await MealQuery.GetSnapshotAsync();
                List<Meal> lstMeal = new List<Meal>();

                foreach (DocumentSnapshot documentSnapshot in MealQuerySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> food = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(food);
                        Meal newMeal = JsonConvert.DeserializeObject<Meal>(json);
                        newMeal.Id = int.Parse(documentSnapshot.Id);
                        lstMeal.Add(newMeal);
                    }
                }

                List<Meal> sortedMealList = lstMeal.OrderBy(x => x.date).ToList();
                return sortedMealList;
            }
            catch
            {
                throw;
            }
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
        public async void UpdateMeal(Meal Meal)
        {
            try
            {
                DocumentReference empRef = _firestore.Collection("Meals").Document(Meal.Id.ToString());
                await empRef.SetAsync(Meal, SetOptions.Overwrite);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Meal> GetMealData(string id)
        {
            try
            {
                DocumentReference docRef = _firestore.Collection("Meals").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Meal emp = snapshot.ConvertTo<Meal>();
                    emp.Id = int.Parse(snapshot.Id);
                    return emp;
                }
                else
                {
                    return new Meal();
                }
            }
            catch
            {
                throw;
            }
        }
        public async void DeleteMeal(string id)
        {
            try
            {
                DocumentReference empRef = _firestore.Collection("Meals").Document(id);
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
