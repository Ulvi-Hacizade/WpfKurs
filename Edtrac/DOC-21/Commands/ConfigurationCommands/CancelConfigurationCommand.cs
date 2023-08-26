using DOC_21.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOC_21.Commands.ConfigurationCommands
{
    public class CancelConfigurationCommand : BaseCommand
    {
        private readonly SqlConfigurationViewModel viewModel;
        public CancelConfigurationCommand(SqlConfigurationViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            viewModel.Window.Close();
        }
    }
}
