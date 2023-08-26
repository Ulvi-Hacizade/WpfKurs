using DOC_21.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.ViewModels.UserControls
{
    public abstract class UCViewModel : BaseViewModel
    {

        // public string Header { get; set; } = "User Control";
        private string header { get; set; } = "User Control";
        public string Header
        {
            get => header;
            set
            {
                header = value;
                OnPropertyChanged(nameof(Header));
            }
        }

        public MessageDialog MessageDialog { get; set; }

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }


        private int currentSituation;
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
