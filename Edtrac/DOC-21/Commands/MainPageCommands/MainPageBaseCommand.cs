using DOC_21.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.MainPageCommands
{
    public abstract class MainPageBaseCommand : BaseCommand
    {
        protected readonly MainPageViewModel viewModel;
        public MainPageBaseCommand(MainPageViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}
