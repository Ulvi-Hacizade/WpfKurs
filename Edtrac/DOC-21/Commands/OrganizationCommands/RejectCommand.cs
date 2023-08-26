using DOC_21.Util;
using DOC_21.ViewModels.UserControls;
using DOC_21.Views.Components.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.OrganizationCommands
{
    public class RejectCommand : OrganizationBaseCommand
    {
        public RejectCommand(OrganizationViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {

            if (viewModel.CurrentSituation == (int)Constants.SITUATIONS.Search || viewModel.CurrentSituation == (int)Constants.SITUATIONS.SELECTED)
            {
                MainGridOrganization mainGrid = new MainGridOrganization();

                viewModel.GridListView.Children.Clear();
                viewModel.Grid.Children.Clear();
                viewModel.ComponentsSize = "*";
                viewModel.Row3Size = "auto";
                viewModel.Grid.Children.Add(mainGrid);
                viewModel.SelectedOrganization = new Models.OrganizationModel();
                viewModel.SelectedOrganization = null;
            }
            
            viewModel.InitializeViewModel();
            viewModel.CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
        }
    }
}
