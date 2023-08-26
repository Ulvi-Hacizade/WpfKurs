using DOC_21.Commands.OrganizationCommands;
using DOC_21.Models;
using DOC_21.Util;
using DOC_21.Views.Components.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DOC_21.ViewModels.UserControls
{

    public class OrganizationViewModel : UCViewModel
    {
        //public OrganizationViewModel()
        //{
        //    Header = "Terrorçular";
        //}

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

        public List<OrganizationModel> AllOrganizations;

        public void InitializeViewModel()
        {
            CurrentOrganization= new OrganizationModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;
           

            Enumerate.Execute(null);
            
            SelectedOrganization = null;
            Organizations = new List<OrganizationModel>(AllOrganizations);
            Header = "Müəllimlər";
        }

        public SaveCommand Save => new SaveCommand(this);
        public SearchCommand Search => new SearchCommand(this);
        public RejectCommand Reject => new RejectCommand(this);
        public EnumerateCommand Enumerate => new EnumerateCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);



        private OrganizationModel currentOrganization;
        public OrganizationModel CurrentOrganization
        {
            get => currentOrganization;
            set
            {

                currentOrganization = value;
                OnPropertyChanged(nameof(CurrentOrganization));
            }
        }

        private List<OrganizationModel> organizations;
        public List<OrganizationModel> Organizations
        {
            get => organizations ?? (organizations = new List<OrganizationModel>());
            set
            {
                organizations = value;
                OnPropertyChanged(nameof(Organizations));
            }
        }

        private OrganizationModel searcTextOrganization;
        public OrganizationModel SearchTextOrganization
        {

            get
            {


                if (searcTextOrganization != null)
                {

                    Organizations = AllOrganizations.Where(x => x.Contains(searcTextOrganization, "Surname") &&
                    x.Contains(searcTextOrganization, "Name") &&
                    x.Contains(searcTextOrganization, "FatherName") &&
                    x.Contains(searcTextOrganization, "OrganizationName") &&
                    x.Contains(searcTextOrganization, "ActivityInformation") &&
                    x.Contains(searcTextOrganization, "DocumentRegistrationNumber") && 
                    x.Contains(searcTextOrganization, "Note") &&
                    x.Contains(searcTextOrganization, "EmployeeSurname") &&
                    x.Contains(searcTextOrganization, "EmployeeName") &&
                    x.Contains(searcTextOrganization, "SearchBeginDate") &&
                    x.Contains(searcTextOrganization, "SearchEndDate")).ToList();

                    Enumerate.Execute(null);
                }
                else
                {

                    searcTextOrganization = new OrganizationModel();
                }


                return searcTextOrganization;

            }
            set
            {

                //if (searcTextCourse == null)
                //{
                //    this.searcTextCourse = new CourseModel();
                //}
                //searcTextCourse.EventNameas = value.EventNameas;

                //if (searcTextCourse == null)
                //{
                //    Courses = new List<CourseModel>(AllCourses);
                //}
                //else
                //{
                //    Courses = AllCourses.Where(x => x.Contains(SearchTextCourse)).ToList();
                //}
                //}
            }
        }



        private OrganizationModel selectedOrganization;
        public OrganizationModel SelectedOrganization
        {
            get => selectedOrganization;
            set
            {
                selectedOrganization = value;
                if (value != null)
                {
                    MainGridOrganization mainGrid = new MainGridOrganization();

                    Grid.Children.Clear();
                    Grid.Children.Add(mainGrid);
                    GridListView.Children.Clear();
                    ComponentsSize = "*";
                    Row3Size = "auto";
                    CurrentOrganization = SelectedOrganization;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;

                }
                OnPropertyChanged(nameof(SelectedOrganization));
            }
        }
    }
}
