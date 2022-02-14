using System;
using System.Collections.Generic;
using System.Text;

namespace TFT.DB.Domain.Abstracts
{
    public interface ICrudRepository<T>
    {
        bool Update(string id, T future);
        List<T> Get();
        void Insert(T future);
        bool Delete(string id);
    }
}
