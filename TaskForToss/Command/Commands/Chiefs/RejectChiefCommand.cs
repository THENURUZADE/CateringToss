using System;
using System.Collections.Generic;
using System.Text;
using TaskForToss.Enums;
using TaskForToss.Models;
using TaskForToss.ViewModels.ControlViewModel;

namespace TaskForToss.Command.Commands.Chiefs
{
    public class RejectChiefCommand : BaseCommand
    {
        private ChiefViewModel chiefViewModel;
        public RejectChiefCommand(ChiefViewModel chiefViewModel)
        {
            this.chiefViewModel = chiefViewModel;
        }

        public override void Execute(object parameter)
        {
            chiefViewModel.SelectedChief = null;
            chiefViewModel.CurrentChief = new ChiefModel();
            chiefViewModel.CurrentSituation = (int)Situation.NORMAL;
        }
    }
}
