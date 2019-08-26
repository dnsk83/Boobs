using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Boobs.ViewModels
{
    public class Command : ICommand
    {
        Action action;

        public event EventHandler CanExecuteChanged;

        public Command(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object arg)
        {
            return true;
        }

        public void Execute(object arg)
        {
            action?.Invoke();
        }
    }
}
