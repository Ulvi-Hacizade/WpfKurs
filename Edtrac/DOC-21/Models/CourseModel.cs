using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Models
{
    public class CourseModel : BaseModel
    {
        public override object this[string name] => throw new NotImplementedException();

        public string EventName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
     
                                   
        public string EventLocation { get; set; }
        public string OrganizersInformations { get; set; }
        public string InstructorsInformations { get; set; }
        public string Participants { get; set; }
        public string Note { get; set; }
        public string DocumentNumber { get; set; }
        public string EmployeeRank { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeName { get; set; }

        public DateTime SearchBeginDate { get; set; } = DateTime.Now;
        public DateTime SearchEndDate { get; set; } = DateTime.Now;



        public string EmployeeFullName => $"{EmployeeRank} {EmployeeSurname} {EmployeeName}";


       


        public bool Contains(CourseModel SearchText, string PropName)
        {
            switch (PropName)
            {
                case "EventName":
                    if (SearchText.EventName == null) { return true; }
                    else { return (SearchText.EventName != null && EventName.Contains(SearchText.EventName)); }
                    
                case "EventLocation":
                    if (SearchText.EventLocation == null) { return true; }
                    else { return (SearchText.EventLocation != null && EventLocation.Contains(SearchText.EventLocation)); }
                case "OrganizersInformations":
                    if (SearchText.OrganizersInformations == null) { return true; }
                    else { return (SearchText.OrganizersInformations != null && OrganizersInformations.Contains(SearchText.OrganizersInformations)); }
                case "InstructorsInformations":
                    if (SearchText.InstructorsInformations == null) { return true; }
                    else { return (SearchText.InstructorsInformations != null && InstructorsInformations.Contains(SearchText.InstructorsInformations)); }
                case "Participants":
                    if (SearchText.Participants == null) { return true; }
                    else { return (SearchText.Participants != null && Participants.Contains(SearchText.Participants)); }
                case "Note":
                    if (SearchText.Note == null) { return true; }
                    else { return (SearchText.Note != null && Note.Contains(SearchText.Note)); }
                case "DocumentNumber":
                    if (SearchText.DocumentNumber == null) { return true; }
                    else { return (SearchText.DocumentNumber != null && DocumentNumber.Contains(SearchText.DocumentNumber)); }
                case "EmployeeSurname":
                    if (SearchText.EmployeeSurname == null) { return true; }
                    else { return (SearchText.EmployeeSurname != null && EmployeeSurname.Contains(SearchText.EmployeeSurname)); }
                case "EmployeeName":
                    if (SearchText.EmployeeName == null) { return true; }
                    else { return (SearchText.EmployeeName != null && EmployeeName.Contains(SearchText.EmployeeName)); }
                case "SearchBeginDate":
                    if (SearchText.SearchBeginDate == null) { return true; }
                    else { return (SearchText.SearchBeginDate != null && Date>=SearchText.SearchBeginDate); }
                case "SearchEndDate":
                    if (SearchText.SearchEndDate == null) { return true; }
                    else { return (SearchText.SearchEndDate != null && Date <= SearchText.SearchEndDate); }

                default: return true;


            }
          
        }
    }
}
