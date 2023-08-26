 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21Core.Domain.Entities
{
    public class Organization : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string OrganizationName { get; set; }
        public string ActivityInformation { get; set; }
        public string DocumentRegistrationNumber { get; set; }
        public DateTime DocumentRegistrationDate { get; set; } = DateTime.Now;
        public string Note { get; set; }
        public string EmployeeRank { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeName { get; set; }


        public string EmployeeFullName => $"{EmployeeRank} {EmployeeSurname} {EmployeeName}";
    }
}
  