using DOC_21.Util;
using DOC_21.ViewModels.UserControls;
using DOC_21.Views.Components.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.DocumentCommands
{
    public class RejectCommand : DocumentBaseCommand
    {
        public RejectCommand(DocumentViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {

            if (viewModel.CurrentSituation == (int)Constants.SITUATIONS.Search)
            {
                MainGridDocument mainGrid = new MainGridDocument();


                viewModel.GridListView.Children.Clear();
                viewModel.Grid.Children.Clear();
                viewModel.ComponentsSize = "*";
                viewModel.Row3Size = "auto";
                viewModel.Grid.Children.Add(mainGrid);
                viewModel.SelectedDocument = new Models.DocumentModel();
                viewModel.SelectedDocument = null;

            }
            viewModel.InitializeViewModel();
            viewModel.CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
        }
    }
}
