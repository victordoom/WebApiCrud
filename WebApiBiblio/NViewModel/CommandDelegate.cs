using System;
using System.Windows.Input;

namespace NViewModel
{
    public class CommandDelegate : ICommand
    {
        Action<object> ExecuteDelegate;
        Func<object, bool> CanExecuteDelegate;

        public CommandDelegate(Func<object, bool> canExecuteDelegate,
           Action<object> executeDelegate)
        {
            this.CanExecuteDelegate = canExecuteDelegate;
            this.ExecuteDelegate = executeDelegate;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var Handler = CanExecuteDelegate;
            bool Result = false;
            if (Handler != null)
            {
                Result = Handler(parameter);
            }

            return Result;
        }

        public void Execute(object parameter)
        {
            var Handler = ExecuteDelegate;
            Handler?.Invoke(parameter);
        }
    }
}
