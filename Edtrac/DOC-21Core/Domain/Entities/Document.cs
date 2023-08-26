using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21Core.Domain.Entities
{
    public class Document : BaseEntity
    {
        public string DocumentName { get; set; }
        public string DocumentCreator { get; set; }
        public DateTime DocumentRegistrationDate { get; set; } = DateTime.Now;
        public string DocumentRegistrationNumber { get; set; }
        public string DocumentContent { get; set; }
        public string Note { get; set; }
    }
}
