using DOC_21.Models;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Mappers
{
    
    public class OrganizationMapper
    {
        public static OrganizationModel Map(Organization organization)
        {
            var model = new OrganizationModel();
            model.Id = organization.Id;
            model.Name = organization.Name;
            model.Surname = organization.Surname;
            model.FatherName = organization.FatherName;
            model.OrganizationName = organization.OrganizationName;
            model.ActivityInformation = organization.ActivityInformation;
            model.DocumentRegistrationNumber = organization.DocumentRegistrationNumber;
            model.DocumentRegistrationDate = organization.DocumentRegistrationDate;
            model.Note = organization.Note;
            model.EmployeeRank = organization.EmployeeRank;
            model.EmployeeName = organization.EmployeeName;
            model.EmployeeSurname = organization.EmployeeSurname;

            return model;
        }

        public static Organization Map(OrganizationModel model, Organization destination)
        {
            destination.Id = model.Id;
            destination.Name = model.Name;
            destination.Surname = model.Surname;
            destination.FatherName = model.FatherName;
            destination.ActivityInformation = model.ActivityInformation;
            destination.DocumentRegistrationNumber = model.DocumentRegistrationNumber;
            destination.DocumentRegistrationDate = model.DocumentRegistrationDate;
            destination.OrganizationName = model.OrganizationName;
            destination.FatherName = model.FatherName;
            destination.Note = model.Note;
            destination.EmployeeRank = model.EmployeeRank;
            destination.EmployeeName = model.EmployeeName;
            destination.EmployeeSurname = model.EmployeeSurname;

            return destination;
        }

    }

}
