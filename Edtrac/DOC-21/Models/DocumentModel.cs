using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Models
{
    public class DocumentModel : BaseModel
    {
        public override object this[string name] => throw new NotImplementedException();

        public string DocumentName { get; set; }
        public string DocumentCreator { get; set; }
        public DateTime DocumentRegistrationDate { get; set; } = DateTime.Now;
        public string DocumentRegistrationNumber { get; set; }
        public string DocumentContent { get; set; }
        public string Note { get; set; }

        public DateTime SearchBeginDate { get; set; } = DateTime.Now;
        public DateTime SearchEndDate { get; set; } = DateTime.Now;


        public bool Contains(DocumentModel SearchText, string PropName)
        {
            switch (PropName)
            {
                case "DocumentName":
                    if (SearchText.DocumentName == null) { return true; }
                    else { return (SearchText.DocumentName != null && DocumentName.Contains(SearchText.DocumentName)); }

                case "DocumentCreator":
                    if (SearchText.DocumentCreator == null) { return true; }
                    else { return (SearchText.DocumentCreator != null && DocumentCreator.Contains(SearchText.DocumentCreator)); }
                case "DocumentRegistrationNumber":
                    if (SearchText.DocumentRegistrationNumber == null) { return true; }
                    else { return (SearchText.DocumentRegistrationNumber != null && DocumentRegistrationNumber.Contains(SearchText.DocumentRegistrationNumber)); }
                case "DocumentContent":
                    if (SearchText.DocumentContent == null) { return true; }
                    else { return (SearchText.DocumentContent != null && DocumentContent.Contains(SearchText.DocumentContent)); }
  
                case "Note":
                    if (SearchText.Note == null) { return true; }
                    else { return (SearchText.Note != null && Note.Contains(SearchText.Note)); }
              
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
