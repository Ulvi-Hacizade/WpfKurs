using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21Core.Domain.Entities
{
    public class Course:BaseEntity
    {
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
    }
}
