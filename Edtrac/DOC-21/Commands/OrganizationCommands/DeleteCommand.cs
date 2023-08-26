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

namespace DOC_21.Commands.OrganizationCommands
{
    public class DeleteCommand:OrganizationBaseCommand
    {
        public DeleteCommand(OrganizationViewModel viewModel) : base(viewModel)
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
                int id = viewModel.SelectedOrganization.Id;
                var branch = DB.OrganizationRepository.FindById(id);
                if (branch != null)
                {
                    branch.IsDeleted = true;
                    DB.OrganizationRepository.Update(branch);
                }

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Organization> branches = DB.OrganizationRepository.Get();
                List<OrganizationModel> models = new List<OrganizationModel>();
                foreach (var entity in branches)
                {
                    var model = OrganizationMapper.Map(entity);
                    models.Add(model);
                }

                viewModel.Organizations = new List<OrganizationModel>(models);

                viewModel.SelectedOrganization = new Models.OrganizationModel();
                viewModel.SelectedOrganization = null;
                viewModel.InitializeViewModel();

               // Logger.LogInformation($"Branch: {id}  has been deleted");
            }
        }
    }
}
