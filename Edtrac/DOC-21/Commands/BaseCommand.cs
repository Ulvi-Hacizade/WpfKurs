using DOC_21Core.Domain.Abstract;
using DOC_21Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DOC_21.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        // BaseCommand doesn't know which actions must do in Execute method. So Execute method must be abstract
        public abstract void Execute(object parameter);


        protected IUnitOfWork DB => Kernel.Db;

    }
}
