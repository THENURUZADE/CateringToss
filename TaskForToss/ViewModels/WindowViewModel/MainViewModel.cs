using System;
using System.Collections.Generic;
using System.Text;
using TaskForToss.Command.Commands.MainWindowCommands;

namespace TaskForToss.ViewModels.WindowViewModel
{
    public class MainViewModel : BaseWindowViewModel
    {
        public MainViewModel()
        {

        }
        public OpenHistoryCommand OpenHistoryCommand => new OpenHistoryCommand(this);
        public OpenChiefCommand OpenChiefCommand => new OpenChiefCommand(this);
    }
}
