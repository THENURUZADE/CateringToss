using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskForToss.Enums;
using TaskForToss.Helpers;
using TaskForToss.Mappers;
using TaskForToss.Models;
using TaskForToss.ViewModels.ControlViewModel;
using TaskForToss.ViewModels.WindowViewModel;
using TaskForToss.Views.Components;
using TFT.DB.DataAccess;
using TFT.DB.Domain.Abstracts;
using TFT.DB.Entity;

namespace TaskForToss.Command.Commands.Chiefs
{
    public class DeleteChiefCommand : BaseCommand
    {
        private ICrudRepository<Chief> MongoCrudRepository => new MongoCrudRepository<Chief>();
        private ChiefViewModel chiefViewModel;
        public DeleteChiefCommand(ChiefViewModel chiefViewModel)
        {
            this.chiefViewModel = chiefViewModel;
        }

        public override void Execute(object parameter)
        {
            //DeleteDialog dialog = new DeleteDialog();
            //DialogViewModel dialogViewModel = new DialogViewModel();
            //dialog.DataContext = dialogViewModel;
            //dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";
            //dialog.ShowDialog();
            //if (dialog.DialogResult == true)
            //{
            //    ChiefMapper mapper = new ChiefMapper();

            //    Chief chief = mapper.Map(chiefViewModel.SelectedChief);  

            //    int id = Convert.ToInt32(chief.Id);

            //    if (MongoCrudRepository.Delete(id.ToString()))
            //    {
            //        int no = chiefViewModel.SelectedChief.No;
            //        id = chiefViewModel.SelectedChief.Id;
                   
            //        chiefViewModel.Chiefs.Remove(chiefViewModel.SelectedChief);   
            //        ChiefModel model = chiefViewModel.AllChiefs.FirstOrDefault(item => item.Id == id);
            //        chiefViewModel.AllChiefs.Remove(model);
            //        List<ChiefModel> models = chiefViewModel.Chiefs.ToList();
            //        List<ChiefModel> allModels = chiefViewModel.AllChiefs;
            //        EnumarationHelper.Numerator(models, no);
            //        EnumarationHelper.Numerator(allModels, no);
            //        chiefViewModel.Chiefs = new ObservableCollection<ChiefModel>(models);
            //        chiefViewModel.AllChiefs = allModels;
            //        chiefViewModel.CurrentSituation = (int)Situation.NORMAL;
            //    }
            //}
            //chiefViewModel.SelectedChief = null;
            //chiefViewModel.CurrentChief = new ChiefModel();
        }
    }
}
