using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Models
{
    public class OrganizationModel : BaseModel
    {
        public override object this[string name] => throw new NotImplementedException();

        public string Surname { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string OrganizationName { get; set; }
        public string ActivityInformation { get; set; }
        public string DocumentRegistrationNumber { get; set; }
        public DateTime DocumentRegistrationDate { get; set; } = DateTime.Now;
        public string Note { get; set; }
        public string EmployeeRank { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeName { get; set; }

        public DateTime SearchBeginDate { get; set; } = DateTime.Now;
        public DateTime SearchEndDate { get; set; } = DateTime.Now;


        public string EmployeeFullName => $"{EmployeeRank} {EmployeeSurname} {EmployeeName}";

        public bool Contains(OrganizationModel SearchText, string PropName)
        {
            switch (PropName)
            {
                case "Name":
                    if (SearchText.Name == null) { return true; }
                    else { return (SearchText.Name != null && Name.Contains(SearchText.Name)); }

                case "Surname":
                    if (SearchText.Surname == null) { return true; }
                    else { return (SearchText.Surname != null && Surname.Contains(SearchText.Surname)); }
                case "FatherName":
                    if (SearchText.FatherName == null) { return true; }
                    else { return (SearchText.FatherName != null && FatherName.Contains(SearchText.FatherName)); }
                case "OrganizationName":
                    if (SearchText.OrganizationName == null) { return true; }
                    else { return (SearchText.OrganizationName != null && OrganizationName.Contains(SearchText.OrganizationName)); }
                case "ActivityInformation":
                    if (SearchText.ActivityInformation == null) { return true; }
                    else { return (SearchText.ActivityInformation != null && ActivityInformation.Contains(SearchText.ActivityInformation)); }
                case "Note":
                    if (SearchText.Note == null) { return true; }
                    else { return (SearchText.Note != null && Note.Contains(SearchText.Note)); }
                case "DocumentRegistrationNumber":
                    if (SearchText.DocumentRegistrationNumber == null) { return true; }
                    else { return (SearchText.DocumentRegistrationNumber != null && DocumentRegistrationNumber.Contains(SearchText.DocumentRegistrationNumber)); }
                case "EmployeeSurname":
                    if (SearchText.EmployeeSurname == null) { return true; }
                    else { return (SearchText.EmployeeSurname != null && EmployeeSurname.Contains(SearchText.EmployeeSurname)); }
                case "EmployeeName":
                    if (SearchText.EmployeeName == null) { return true; }
                    else { return (SearchText.EmployeeName != null && EmployeeName.Contains(SearchText.EmployeeName)); }
                case "SearchBeginDate":
                    if (SearchText.SearchBeginDate == null) { return true; }
                    else { return (SearchText.SearchBeginDate != null && DocumentRegistrationDate >= SearchText.SearchBeginDate); }
                case "SearchEndDate":
                    if (SearchText.SearchEndDate == null) { return true; }
                    else { return (SearchText.SearchEndDate != null && DocumentRegistrationDate <= SearchText.SearchEndDate); }

                default: return true;


            }

        }
    }
}
