using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskForToss.ViewModels.WindowViewModel;
using TaskForToss.Views.Controls;
using TaskForToss.Views.Windows;

namespace TaskForToss
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainWindow mainWindow = new MainWindow();
            MainViewModel mainViewModel = new MainViewModel();
            mainWindow.DataContext = mainViewModel;
            mainViewModel.Window = mainWindow;
            MainWindow = mainWindow;
            
            MainWindow.Show();
        }
    }
}
