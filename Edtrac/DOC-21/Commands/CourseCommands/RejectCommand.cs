using DOC_21.Util;
using DOC_21.ViewModels.UserControls;
using DOC_21.Views.Components.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.CourseCommands
{
    public class RejectCommand : CourseBaseCommand
    {
        public RejectCommand(CourseViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            if (viewModel.CurrentSituation == (int)Constants.SITUATIONS.Search || viewModel.CurrentSituation == (int)Constants.SITUATIONS.SELECTED)
            {
                MainGridCourse mainGrid = new MainGridCourse();
             

                viewModel.GridListView.Children.Clear();
                viewModel.Grid.Children.Clear();
                viewModel.ComponentsSize = "*";
                viewModel.Row3Size = "auto";
                viewModel.Grid.Children.Add(mainGrid);
                viewModel.SelectedCourse = new Models.CourseModel();
                viewModel.SelectedCourse = null;
                
            }

            viewModel.InitializeViewModel();
            viewModel.CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
        }
    }
}
