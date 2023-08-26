using DOC_21.Mappers;
using DOC_21.Models;
using DOC_21.Util;
using DOC_21.ViewModels;
using DOC_21.ViewModels.UserControls;
using DOC_21.Views.Components;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.CourseCommands
{
    public class DeleteCommand : CourseBaseCommand
    {
        public DeleteCommand(CourseViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {

            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedCourse.Id;
                var course = DB.CourseRepository.FindById(id);
                if (course != null)
                {
                    course.IsDeleted = true;
                    DB.CourseRepository.Update(course);
                }

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Course> courses = DB.CourseRepository.Get();
                List<CourseModel> models = new List<CourseModel>();
                foreach (var cours in courses)
                {
                    var model = CourseMapper.Map(cours);
                    models.Add(model);
                }
                viewModel.AllCourses = new List<CourseModel>(models);

                viewModel.InitializeViewModel();
                //courseControl.DataContext = viewModel;
                //viewModel.Grid = courseControl.grdComponents;
                //viewModel.GridListView = courseControl.grdListView;
            }
        }
    }
}
