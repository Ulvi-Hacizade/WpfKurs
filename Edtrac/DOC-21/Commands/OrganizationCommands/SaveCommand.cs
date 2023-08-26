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

namespace DOC_21.Commands.OrganizationCommands
{
    public class SaveCommand : OrganizationBaseCommand
    {

        public SaveCommand(OrganizationViewModel viewModel) : base(viewModel)
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
                        var organization = OrganizationMapper.Map(viewModel.CurrentOrganization, new Organization());
                        organization.IsDeleted = false;
                        organization.CreationDate = DateTime.Now;
                        organization.Creator = Kernel.AuthenticatedUser;

                        DB.OrganizationRepository.Add(organization);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentOrganization.Id;
                        var existingOrganization = DB.OrganizationRepository.FindById(id);
                        if (existingOrganization != null)
                        {
                            existingOrganization = OrganizationMapper.Map(viewModel.CurrentOrganization, existingOrganization);
                            existingOrganization.CreationDate = DateTime.Now;
                            existingOrganization.Creator = Kernel.AuthenticatedUser;
                            DB.OrganizationRepository.Update(existingOrganization);
                        }
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

                    viewModel.AllOrganizations = new List<OrganizationModel>(models);

                    
                    viewModel.SelectedOrganization = null;
                    viewModel.InitializeViewModel();
                }
            }
        }


        private bool IsValid()
        {
            var organization = viewModel.CurrentOrganization;

            if (string.IsNullOrEmpty(organization.EmployeeName))
            {
                MessageBox.Show("Məlumatı daxil edən əməkdaşın adı və soyadı mütləq daxil edilməlidir!");
                return false;
            }
            if (string.IsNullOrEmpty(organization.EmployeeSurname))
            {
                MessageBox.Show("Məlumatı daxil edən əməkdaşın adı və soyadı mütləq daxil edilməlidir!");
                return false;
            }
            if (string.IsNullOrEmpty(organization.DocumentRegistrationNumber))
            {
                MessageBox.Show("Sənədin qeydiyyat nömrəsi mütləq daxil edilməlidir!");
                return false;
            }
            if (string.IsNullOrEmpty(organization.OrganizationName))
            {
                MessageBox.Show("Terror təşkilatının adı mütləq daxil edilməlidir!");
                return false;
            }

            return true;
        }

        private void CorrectData()
        {
            if (viewModel.CurrentOrganization.Name != null)
            {
                viewModel.CurrentOrganization.Name = viewModel.CurrentOrganization.Name.Trim();
            }

            if (viewModel.CurrentOrganization.Surname != null)
            {
                viewModel.CurrentOrganization.Surname = viewModel.CurrentOrganization.Surname.Trim();
            }

            if (viewModel.CurrentOrganization.FatherName != null)
            {
                viewModel.CurrentOrganization.FatherName = viewModel.CurrentOrganization.FatherName.Trim();
            }

            if (viewModel.CurrentOrganization.OrganizationName != null)
            {

                viewModel.CurrentOrganization.OrganizationName = viewModel.CurrentOrganization.OrganizationName.Trim();
            }

            if (viewModel.CurrentOrganization.ActivityInformation != null)
            {
                viewModel.CurrentOrganization.ActivityInformation = viewModel.CurrentOrganization.ActivityInformation.Trim();
            }

            if (viewModel.CurrentOrganization.DocumentRegistrationNumber != null)
            {
                viewModel.CurrentOrganization.DocumentRegistrationNumber = viewModel.CurrentOrganization.DocumentRegistrationNumber.Trim();
            }

            if (viewModel.CurrentOrganization.Note != null)
            {
                viewModel.CurrentOrganization.Note = viewModel.CurrentOrganization.Note.Trim();
            }

            viewModel.CurrentOrganization.EmployeeRank = viewModel.CurrentOrganization.EmployeeRank.Trim();
            viewModel.CurrentOrganization.EmployeeName = viewModel.CurrentOrganization.EmployeeName.Trim();
            viewModel.CurrentOrganization.EmployeeSurname = viewModel.CurrentOrganization.EmployeeSurname.Trim();
            
           
        }
    }
}
