using System;
using System.Collections.Generic;
using System.Text;

namespace TaskForToss.ViewModels
{
    public abstract class BaseControlViewModel : BaseViewModel
    { 
        public abstract string Header { get; }
        //public CurrentSituation CurrentSituation { get; set; } = CurrentSituation.NORMAL;
        protected int currentSituation = 1;
        public int CurrentSituation
        {
            get => currentSituation;
            set
            {
                currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }
    }
}
