using DOC_21.Util;
using DOC_21.ViewModels.UserControls;
using DOC_21.Views.Components.Course;
using DOC_21.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.CourseCommands
{
    public class SearchCommand : CourseBaseCommand
    {

        public SearchCommand(CourseViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            

            CourseSearch search = new CourseSearch();
            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(search);

            viewModel.ComponentsSize = "auto";
            viewModel.Row3Size = "*";

            CourseListView list = new CourseListView();
            viewModel.GridListView.Children.Clear();
            viewModel.GridListView.Children.Add(list);

            viewModel.CurrentSituation = (int)Constants.SITUATIONS.Search;
            //viewModel.OpenId = 0;
            viewModel.Header = "Kurslar üzrə axtarış";
            viewModel.SelectedCourse = null;






        }
    }
}
