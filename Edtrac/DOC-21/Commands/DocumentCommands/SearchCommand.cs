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
    public class SearchCommand : DocumentBaseCommand
    {

        public SearchCommand(DocumentViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {

            DocumentSearch search = new DocumentSearch();
            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(search);
            viewModel.ComponentsSize = "auto";
            viewModel.Row3Size = "*";

            DocumentListView list = new DocumentListView();
            viewModel.GridListView.Children.Clear();
            viewModel.GridListView.Children.Add(list);

            viewModel.CurrentSituation = (int)Constants.SITUATIONS.Search;
            viewModel.Header = "Müraciətlər üzrə axtarış";
            viewModel.SelectedDocument = null;


        }
    }
}
