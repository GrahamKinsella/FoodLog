using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodLog.DataAccess
{
    public abstract class BaseDataAccessLayer
    {
        protected readonly FirestoreDb _firestore;
        public BaseDataAccessLayer(FirestoreDb firestore)
        {
            _firestore = firestore;
        }
    }
}
