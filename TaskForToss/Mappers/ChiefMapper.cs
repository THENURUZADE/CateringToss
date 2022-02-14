using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using TaskForToss.Models;
using TFT.DB.Entity;

namespace TaskForToss.Mappers
{
    public class ChiefMapper : BaseMapper<Chief, ChiefModel>
    {
        public override ChiefModel Map(Chief chief)
        {
            ChiefModel chiefModel = new ChiefModel();

            chiefModel.Email = chief.Email;
            chiefModel.Name = chief.Name;
            chiefModel.Phone = chief.Phone;
            chiefModel.EffectiveDate = chief.EffectiveDate;
            chiefModel.Id= chief.Id;

            return chiefModel;
        }

        public override Chief Map(ChiefModel chiefModel)
        {
            Chief chief = new Chief();

            chief.Email = chiefModel.Email;
            chief.Name = chiefModel.Name;
            chief.Phone = chiefModel.Phone;
            chief.EffectiveDate = chiefModel.EffectiveDate;
            chief.Id = chiefModel.Id; // mence lazimsizdir bunu etmek 
           
            return chief;
        }
    }
}
