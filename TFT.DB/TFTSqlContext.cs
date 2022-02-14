using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Text;
using TFT.Mapping;

namespace TFT.DB
{
    public class TFTSqlContext
    {
        private static ISessionFactory session;
        private static ISessionFactory CreateSession()
        {
            if (session != null)
                return session;

            FluentConfiguration config = Fluently.Configure()
            .Database(PostgreSQLConfiguration.Standard.ConnectionString(
                x => x.Username("postgres")
                .Password("postgre123")
                .Port(5432)
                .Host("localhost")
                .Database("TaskForToss")))
              
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CommusionMapping>())
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FutureMapping>())
            
            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true));
            
            session = config.BuildSessionFactory();
            return session;
        }
        
        public static ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }
    }
}
