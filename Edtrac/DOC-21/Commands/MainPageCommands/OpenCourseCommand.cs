using DOC_21.Mappers;
using DOC_21.Models;
using DOC_21.ViewModels.UserControls;
using DOC_21.ViewModels.Windows;
using DOC_21.Views.UserControls;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.MainPageCommands
{
    public class OpenCourseCommand : MainPageBaseCommand
    {
        public OpenCourseCommand(MainPageViewModel viewModel) : base(viewModel)
        {
        }

        public override void Execute(object parameter)
        {
           

            CourseControl courseControl = new CourseControl();
            

            CourseViewModel courseViewModel = new CourseViewModel();

            courseViewModel.MessageDialog = courseControl.MessageDialog;

            List<Course> courses = DB.CourseRepository.Get();
            List<CourseModel> models = new List<CourseModel>();
            foreach (var course in courses)
            {
                var model = CourseMapper.Map(course);
                models.Add(model);
            }
            courseViewModel.AllCourses = new List<CourseModel>(models);

            courseViewModel.InitializeViewModel();
            courseControl.DataContext = courseViewModel;
            courseViewModel.Grid = courseControl.grdComponents1;
            courseViewModel.GridListView = courseControl.grdListView;
            courseViewModel.ComponentsSize = "*";
            courseViewModel.Row3Size = "auto";

            //mainpagein viewmodel\in gotururem
            courseViewModel.MainPageViewModel = viewModel;





            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(courseControl);
        }
    }
}
