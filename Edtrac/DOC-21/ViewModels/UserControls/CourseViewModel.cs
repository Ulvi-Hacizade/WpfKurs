using DOC_21.Commands.CourseCommands;
using DOC_21.Models;
using DOC_21.Util;
using DOC_21.ViewModels.Windows;
using DOC_21.Views.Components.Course;
using DOC_21.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DOC_21.ViewModels.UserControls
{
    public class CourseViewModel : UCViewModel
    {
        
        double height { get; set; } = SystemParameters.WorkArea.Height;

        public double Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        string row3Size { get; set; }
        public string Row3Size
        {
            get => row3Size;
            set
            {
                row3Size = value;
                OnPropertyChanged(nameof(Row3Size));
            }
        }

        string componentsSize { get; set; }
        public string ComponentsSize
        {
            get => componentsSize;
            set
            {
                componentsSize = value;
                OnPropertyChanged(nameof(ComponentsSize));
            }
        }
        public Grid Grid { get; set; }

        public Grid GridListView { get; set; }

        public MainPageViewModel MainPageViewModel { get; set; }
        public void InitializeViewModel()
        {
            CurrentCourse = new CourseModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;

            

            Enumerate.Execute(null);

            SelectedCourse = null;
            Header = "Kurslar";

            Courses = new List<CourseModel>(AllCourses);
        }


        public SearchCommand Search => new SearchCommand(this);
        public RejectCommand Reject => new RejectCommand(this);
        public EnumarateCourseCommand Enumerate => new EnumarateCourseCommand(this);
        public SaveCommand Save => new SaveCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);


        public List<CourseModel> AllCourses;

        private CourseModel currentCourse;
        
        public CourseModel CurrentCourse
        {
            get => currentCourse;
            set
            {

                currentCourse = value;
                OnPropertyChanged(nameof(CurrentCourse));
            }
        }

        private List<CourseModel> courses;
        public List<CourseModel> Courses
        {
            get => courses ?? (courses = new List<CourseModel>());
            set
            {
                courses = value;
                OnPropertyChanged(nameof(Courses));
            }
        }

        private CourseModel selectedCourse;
        public CourseModel SelectedCourse
        {
            get => selectedCourse;
            set
            {
                selectedCourse = value;
                if (value != null)
                {
                    MainGridCourse mainGrid = new MainGridCourse();

                    Grid.Children.Clear();
                    Grid.Children.Add(mainGrid);
                    GridListView.Children.Clear();
                    ComponentsSize = "*";
                    Row3Size = "auto";
                    CurrentCourse = SelectedCourse;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;

                }
                OnPropertyChanged(nameof(SelectedCourse));
            }
        }

        private CourseModel searcTextCourse;
        public CourseModel SearchTextCourse
        {
            
            get
            {


                if (searcTextCourse != null)
                {
                   
                        Courses = AllCourses.Where(x => x.Contains(searcTextCourse,"EventName") && 
                        x.Contains(searcTextCourse, "EventLocation") &&
                        x.Contains(searcTextCourse, "OrganizersInformations") && 
                        x.Contains(searcTextCourse, "InstructorsInformations") &&
                        x.Contains(searcTextCourse, "Participants") &&
                        x.Contains(searcTextCourse, "Note") && x.Contains(searcTextCourse, "DocumentNumber") &&
                        x.Contains(searcTextCourse, "EmployeeSurname") &&
                        x.Contains(searcTextCourse, "EmployeeName") &&
                        x.Contains(searcTextCourse, "SearchBeginDate") &&
                        x.Contains(searcTextCourse, "SearchEndDate")).ToList();

                    Enumerate.Execute(null);
                }
                else
                {
                    
                    searcTextCourse = new CourseModel();
                }


                return searcTextCourse;

            }
           
        }



      


    }
}
