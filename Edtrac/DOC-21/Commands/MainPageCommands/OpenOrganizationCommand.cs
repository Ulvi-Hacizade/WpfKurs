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
   
    public class OpenOrganizationCommand : MainPageBaseCommand
    {
        public OpenOrganizationCommand(MainPageViewModel viewModel) : base(viewModel)
        {
        }

        public override void Execute(object parameter)
        {
            OrganizationControl organizationControl = new OrganizationControl();

            OrganizationViewModel organizationViewModel = new OrganizationViewModel();

            organizationViewModel.MessageDialog = organizationControl.MessageDialog;

            List<Organization> organizations = DB.OrganizationRepository.Get();
            List<OrganizationModel> models = new List<OrganizationModel>();
            foreach (var organization in organizations)
            {
                var model = OrganizationMapper.Map(organization);
                models.Add(model);
            }
            organizationViewModel.AllOrganizations = new List<OrganizationModel>(models);


            organizationViewModel.InitializeViewModel();
            organizationControl.DataContext = organizationViewModel;
            organizationViewModel.Grid = organizationControl.grdComponents1;
            organizationViewModel.GridListView = organizationControl.grdListView;
            organizationViewModel.ComponentsSize = "*";
            organizationViewModel.Row3Size = "auto";



            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(organizationControl);
        }
    }
}
