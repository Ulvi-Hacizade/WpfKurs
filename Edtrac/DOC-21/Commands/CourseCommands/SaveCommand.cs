using DOC_21.Mappers;
using DOC_21.Models;
using DOC_21.Util;
using DOC_21.ViewModels.UserControls;
using DOC_21Core.Domain.Entities;
using DOC_21Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DOC_21.Commands.CourseCommands
{
    public class SaveCommand : CourseBaseCommand
    {
        public SaveCommand(CourseViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            int situation = viewModel.CurrentSituation;
            if (situation == (int)Constants.SITUATIONS.NORMAL)
            {
                viewModel.CurrentSituation = (int)Constants.SITUATIONS.ADD;
            }
            else if (situation == (int)Constants.SITUATIONS.SELECTED)
            {
                viewModel.CurrentSituation = (int)Constants.SITUATIONS.EDIT;
            }
            else
            {
                if (IsValid())
                {
                    CorrectData();

                    if (situation == (int)Constants.SITUATIONS.ADD)
                    {
                        var course = CourseMapper.Map(viewModel.CurrentCourse, new Course());
                        course.IsDeleted = false;
                        course.CreationDate = DateTime.Now;
                        course.Creator = Kernel.AuthenticatedUser;

                        DB.CourseRepository.Add(course);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentCourse.Id;
                        var existingCourse = DB.CourseRepository.FindById(id);
                        if (existingCourse != null)
                        {
                            existingCourse = CourseMapper.Map(viewModel.CurrentCourse, existingCourse);
                            existingCourse.CreationDate = DateTime.Now;
                            existingCourse.Creator = Kernel.AuthenticatedUser;
                            DB.CourseRepository.Update(existingCourse);
                        }
                    }

                    viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                    BusinessUtil.DoAnimation(viewModel.MessageDialog);

                    // reload all branches

                    List<Course> courses = DB.CourseRepository.Get();
                    List<CourseModel> models = new List<CourseModel>();
                    foreach (var course in courses)
                    {
                        var model = CourseMapper.Map(course);
                        models.Add(model);
                    }
                    viewModel.AllCourses = new List<CourseModel>(models);

                    viewModel.SelectedCourse = null;
                    viewModel.InitializeViewModel();
                }
            }
        }

        private bool IsValid()
        {
            var course = viewModel.CurrentCourse;

            if (string.IsNullOrEmpty(course.EmployeeName))
            {
                MessageBox.Show("Məlumatı daxil edən əməkdaşın adı və soyadı mütləq daxil edilməlidir!");
                return false;
            }
            if (string.IsNullOrEmpty(course.EmployeeSurname))
            {
                MessageBox.Show("Məlumatı daxil edən əməkdaşın adı və soyadı mütləq daxil edilməlidir!");
                return false;
            }
            if (string.IsNullOrEmpty(course.EventName))
            {
                MessageBox.Show("Tədbirin adı mütləq daxil edilməlidir!");
                return false;
            }
            if (string.IsNullOrEmpty(course.EventLocation))
            {
                MessageBox.Show("Tədbirin keçirildiyi yer mütləq daxil edilməlidir!");
                return false;
            }
            if (string.IsNullOrEmpty(course.DocumentNumber))
            {
                MessageBox.Show("Sənədin nömrəsi mütləq daxil edilməlidir!");
                return false;
            }

            return true;
        }

        private void CorrectData()
        {
            if (viewModel.CurrentCourse.EventName != null)
            {
                viewModel.CurrentCourse.EventName = viewModel.CurrentCourse.EventName.Trim();
            }

            if (viewModel.CurrentCourse.EventLocation != null)
            {
                viewModel.CurrentCourse.EventLocation = viewModel.CurrentCourse.EventLocation.Trim();
            }

            if (viewModel.CurrentCourse.OrganizersInformations != null)
            {
                viewModel.CurrentCourse.OrganizersInformations = viewModel.CurrentCourse.OrganizersInformations.Trim();
            }

            if (viewModel.CurrentCourse.InstructorsInformations != null)
            {

                viewModel.CurrentCourse.InstructorsInformations = viewModel.CurrentCourse.InstructorsInformations.Trim();
            }

            

            if (viewModel.CurrentCourse.Note != null)
            {
                viewModel.CurrentCourse.Note = viewModel.CurrentCourse.Note.Trim();
            }

            viewModel.CurrentCourse.EmployeeRank = viewModel.CurrentCourse.EmployeeRank.Trim();
            viewModel.CurrentCourse.EmployeeName = viewModel.CurrentCourse.EmployeeName.Trim();
            viewModel.CurrentCourse.EmployeeSurname = viewModel.CurrentCourse.EmployeeSurname.Trim();


        }
    }

   
}
