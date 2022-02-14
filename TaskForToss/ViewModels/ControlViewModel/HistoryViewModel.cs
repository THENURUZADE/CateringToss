using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskForToss.Command.Commands.HistoryCommands;
using TFT.Models.Models;

namespace TaskForToss.ViewModels.ControlViewModel
{
    public class HistoryViewModel
    {
        public HistoryViewModel()
        {

        }
        public CommusionModel CurrentCommusion { get; set; } = new CommusionModel();
        public ObservableCollection<CommusionModel> Commusions { get; set; }
        public int Id { get; set; }
        public OkCommand OkCommand => new OkCommand(this);
        public List<FutureModel> FutureModels { get; set; }
    }
}
