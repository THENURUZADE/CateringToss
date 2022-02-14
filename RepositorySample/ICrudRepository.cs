using System;
using System.Collections.Generic;
using System.Text;

namespace RepositorySample
{
   public interface ICrudRepository<T>
   {
        IList<T> Get();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
   }
}
