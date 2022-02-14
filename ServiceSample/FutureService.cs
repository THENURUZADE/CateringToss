using IServiceSample;
using NHibernate;
using RepositorySample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFT.DB;
using TFT.Models.Models;

namespace ServiceSample
{
    public class FutureService : IFutureService
    {
        private readonly BaseRepository<FutureModel> repository = new BaseRepository<FutureModel>();

        public void FutureAdded(FutureModel model)
        {
            repository.Insert(model);
        }

        public IList<FutureModel> Get()
        {
            return repository.Get();
        }
      
    }
}
