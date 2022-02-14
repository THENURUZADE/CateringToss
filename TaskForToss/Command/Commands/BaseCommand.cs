using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TaskForToss.Command.Commands
{
    public abstract class BaseCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public virtual  bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
       
    }
}
