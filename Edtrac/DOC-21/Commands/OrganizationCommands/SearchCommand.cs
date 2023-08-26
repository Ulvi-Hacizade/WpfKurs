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
    public class SearchCommand : OrganizationBaseCommand
    {

        public SearchCommand(OrganizationViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {

            OrganizationSearch search = new OrganizationSearch();
            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(search);

            viewModel.ComponentsSize = "auto";
            viewModel.Row3Size = "*";

            OrganizationListView list = new OrganizationListView();
            viewModel.GridListView.Children.Clear();
            viewModel.GridListView.Children.Add(list);

            viewModel.CurrentSituation = (int)Constants.SITUATIONS.Search;
            viewModel.Header = "Müəllimlər üzrə axtarış";


        }
    }
}
