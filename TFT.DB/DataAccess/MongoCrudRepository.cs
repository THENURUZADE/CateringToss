using System;
using System.Collections.Generic;
using System.Text;
using TFT.DB.Domain.Abstracts;

namespace TFT.DB.DataAccess
{
    public class MongoCrudRepository<T> : ICrudRepository<T>
    {
        private TFTMongoDB<T> MongoDB => TFTMongoDB<T>.ClientAsSingleton();
        public void Insert(T future)
        {
            MongoDB.InsertModel(future);
        }
        public bool Update(string id,T future)
        {
           return MongoDB.Update(id,future);
        }
        public List<T> Get()
        {
            return MongoDB.Get();
        }
        public bool Delete (string id)
        {
            return MongoDB.Delete(id);
        }
    }
}
