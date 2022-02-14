
using System;
using System.Collections.Generic;
using System.Text;
using TaskForToss.Enums;
using TaskForToss.Mappers;
using TaskForToss.ViewModels.ControlViewModel;
using TFT.DB.DataAccess;
using TFT.DB.Entity;
using TFT.DB.Domain.Abstracts;
using TaskForToss.Models;
using MongoDB.Bson;

namespace TaskForToss.Command.Commands.Chiefs
{
    public class SaveChiefCommand : BaseCommand
    {
        private ICrudRepository<Chief> MongoCrudRepository => new MongoCrudRepository<Chief>();
     
        private ChiefViewModel chiefViewModel;
        public SaveChiefCommand(ChiefViewModel chiefViewModel)
        {
            this.chiefViewModel = chiefViewModel;
        }
        public override void Execute(object parameter)
        {
            if (chiefViewModel.CurrentSituation == (int)Situation.NORMAL)
            {
                chiefViewModel.CurrentSituation = (int)Situation.ADD;
            }
            else if (chiefViewModel.CurrentSituation == (int)Situation.ADD || chiefViewModel.CurrentSituation == (int)Situation.EDIT)
            {
                if (chiefViewModel.CurrentChief.IsValid())
                {
                    ChiefMapper chiefMapper = new ChiefMapper();
                    chiefViewModel.CurrentChief.EffectiveDate = new DateTime(chiefViewModel.CurrentChief.Year, chiefViewModel.CurrentChief.Month, chiefViewModel.CurrentChief.Day);

                    Chief chief = chiefMapper.Map(chiefViewModel.CurrentChief);
                    //chief.Creator = Kernel.CurrentUser;

                    if (chiefViewModel.CurrentChief.Id == ObjectId.Empty)
                    {
                        MongoCrudRepository.Insert(chief);
                        chiefViewModel.CurrentChief.No = chiefViewModel.AllChiefs.Count + 1;
                        chiefViewModel.Chiefs.Add(chiefViewModel.CurrentChief);
                        chiefViewModel.AllChiefs.Add(chiefViewModel.CurrentChief);
                    }
                    else
                    {
                        bool k = MongoCrudRepository.Update(Convert.ToString(chief.Id), chief);
                        if (k)
                        {
                            ChiefModel model = chiefViewModel.SelectedChief;
                            int index = chiefViewModel.Chiefs.IndexOf(model);
                            int indexAll = chiefViewModel.AllChiefs.IndexOf(model);
                            chiefViewModel.AllChiefs[indexAll] = chiefViewModel.CurrentChief;
                            chiefViewModel.Chiefs[index] = chiefViewModel.CurrentChief;
                        }
                    }
                    chiefViewModel.SelectedChief = null;
                    chiefViewModel.CurrentChief = new ChiefModel();
                    chiefViewModel.CurrentSituation = (int)Situation.NORMAL;
                }
                
            }
            else if (chiefViewModel.CurrentSituation == (int)Situation.SELECTED)
            {
                chiefViewModel.CurrentSituation = (int)Situation.EDIT;
            }
        }
    }
}
