using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskForToss.Helpers;
using TaskForToss.Models;
using TaskForToss.ViewModels.ControlViewModel;
using TaskForToss.ViewModels.WindowViewModel;
using TaskForToss.Views.Controls;
using TaskForToss.Views.Windows;

namespace TaskForToss.Command.Commands.MainWindowCommands
{
    public class OpenChiefCommand : BaseCommand
    {
        private MainViewModel mainViewModel;
        public OpenChiefCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            ChiefControl chiefControl = new ChiefControl();
            ChiefViewModel chiefViewModel = new ChiefViewModel();
            chiefControl.DataContext = chiefViewModel;
            DataProvider dataProvider = new DataProvider();
            List<ChiefModel> models = dataProvider.GetChiefs();

            EnumarationHelper.Numerator(models);
            chiefViewModel.AllChiefs = models;
            chiefViewModel.Chiefs = new ObservableCollection<ChiefModel>(models);
            //mainViewModel.Window.grdMain ----- niye islemir ? 
            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.grdMain.Children.Clear();
            mainWindow.grdMain.Children.Add(chiefControl);
        }
    }
}
