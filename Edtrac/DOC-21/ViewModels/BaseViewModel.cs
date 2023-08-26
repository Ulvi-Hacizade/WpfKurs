using DOC_21Core.Domain.Abstract;
using DOC_21Core.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.ViewModels
{

    // you can not create object for BaseViewModel, because it is abstract class
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected IUnitOfWork DB => Kernel.Db;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
