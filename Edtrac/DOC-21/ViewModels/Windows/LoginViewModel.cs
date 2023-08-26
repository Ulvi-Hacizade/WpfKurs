using DOC_21.Commands;
using DOC_21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DOC_21.ViewModels.Windows
{
    public class LoginViewModel : WindowViewModel
    {
        public LoginModel LoginModel { get; set; } = new LoginModel();


        public LoginCommand Login => new LoginCommand(this);

        private Visibility errorVisibility = Visibility.Collapsed;
        public Visibility ErrorVisibility
        {
            get => errorVisibility;
            set
            {
                errorVisibility = value;
                OnPropertyChanged(nameof(ErrorVisibility));
            }
        }

    }
}
