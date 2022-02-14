using System;
using System.Collections.Generic;
using System.Text;
using TaskForToss.Mappers;
using TaskForToss.Models;
using TFT.DB.DataAccess;
using TFT.DB.Domain.Abstracts;
using TFT.DB.Entity;

namespace TaskForToss.Helpers
{
    public class DataProvider
    {
        private ICrudRepository<Chief> MongoCrudRepository => new MongoCrudRepository<Chief>();

        public List<ChiefModel> GetChiefs()
        {
            ChiefMapper mapper = new ChiefMapper();
            List<Chief> chiefs = MongoCrudRepository.Get() ;
            List<ChiefModel> models = new List<ChiefModel>();
            foreach (var item in chiefs)
            {
                models.Add(mapper.Map(item));
            }
            return models;
        }
    }
}
