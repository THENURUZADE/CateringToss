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
    public class CommusionService : ICommusionService
    {
        private readonly BaseRepository<CommusionModel> repository = new BaseRepository<CommusionModel>();

        public void CommusionAdded(CommusionModel model)
        {
            repository.Insert(model);
        }

        public IList<CommusionModel> Get()
        {
            return repository.Get();
        }
        public IList<CommusionModel> GetByFutureIdAndName(string futureTypeName, int futureId)
        {
            using (ISession session = TFTSqlContext.SessionOpen())
            {
                return session.Query<CommusionModel>().Where(x => x.FutureId == futureId && x.FutureTypeName == futureTypeName).ToList();
            }
        }
    }
}
