using ServiceSample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TaskForToss.ViewModels.ControlViewModel;
using TFT.Models.Models;

namespace TaskForToss.Command.Commands.HistoryCommands
{
    public class OkCommand : BaseCommand
    {
        private HistoryViewModel viewModel;
        public OkCommand(HistoryViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        private readonly CommusionService commusionService = new CommusionService();

        public override void Execute(object parameter)
        {
            IList<CommusionModel> a = commusionService.GetByFutureIdAndName(viewModel.CurrentCommusion.FutureTypeName, viewModel.Id);
            viewModel.Commusions = new ObservableCollection<CommusionModel>(a);

        }
    }
}
