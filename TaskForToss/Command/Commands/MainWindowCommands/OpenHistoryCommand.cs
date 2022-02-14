using ServiceSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskForToss.ViewModels.ControlViewModel;
using TaskForToss.ViewModels.WindowViewModel;
using TaskForToss.Views.Controls;
using TaskForToss.Views.Windows;

namespace TaskForToss.Command.Commands.MainWindowCommands
{
    public class OpenHistoryCommand : BaseCommand
    {
        private MainViewModel mainViewModel;
        public OpenHistoryCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        private readonly FutureService futureService = new FutureService();

        public override void Execute(object parameter)
        {
            ViewHistoryControl chiefControl = new ViewHistoryControl();
            HistoryViewModel chiefViewModel = new HistoryViewModel();
            chiefViewModel.FutureModels = futureService.Get().ToList();
            chiefControl.DataContext = chiefViewModel;
            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.grdMain.Children.Clear();
            mainWindow.grdMain.Children.Add(chiefControl);
        }
    }
}
