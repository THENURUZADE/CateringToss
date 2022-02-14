using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TFT.DB;

namespace RepositorySample
{
    public class BaseRepository<T> : ICrudRepository<T> where T : class
    {
        public void Delete(T entity)
        {
            using (ISession session = TFTSqlContext.SessionOpen())
            {
                using (ITransaction transaction = session.BeginTransaction(0))
                {
                    try
                    {
                        session.Delete(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                            transaction.Rollback();

                        throw new Exception("Delete xetasi : " + ex.Message);
                    }
                }
            }
        }

       

        public void Insert(T entity)
        {
            using (ISession session = TFTSqlContext.SessionOpen())
            {
                using (ITransaction transaction = session.BeginTransaction(0))
                {
                    try
                    {
                        session.Save(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                            transaction.Rollback(); 
                       
                        throw new Exception("Insert xetasi : " + ex.Message);
                    }
                }
            }
        }

        public void Update(T entity)
        {
            using (ISession session = TFTSqlContext.SessionOpen())
            {
                using (ITransaction transaction = session.BeginTransaction(0))
                {
                    try
                    {
                        session.Update(entity);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                            transaction.Rollback();

                        throw new Exception("Update xetasi : " + ex.Message);
                    }
                }
            }
        }
        public T GetById(int id)
        {
            using (ISession session = TFTSqlContext.SessionOpen())
            {
                return session.Get<T>(id);
            }
        }

        public IList<T> Get()
        {
            using(ISession session = TFTSqlContext.SessionOpen())
            {
                return session.Query<T>().ToList();
            }
        }
      
    }
}
