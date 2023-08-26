using DOC_21.Models;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Mappers
{
    public class DocumentMapper
    {

        public static DocumentModel Map(Document document)
        {
            var model = new DocumentModel();
            model.Id = document.Id;
            model.DocumentName = document.DocumentName;
            model.DocumentCreator = document.DocumentCreator;
            model.DocumentRegistrationDate = document.DocumentRegistrationDate;
            model.DocumentRegistrationNumber = document.DocumentRegistrationNumber;
            model.DocumentContent = document.DocumentContent;
            model.Note = document.Note;
 
            return model;
        }
        public static Document Map(DocumentModel model, Document destination)
        {
            destination.Id = model.Id;
            destination.DocumentName = model.DocumentName;
            destination.DocumentCreator = model.DocumentCreator;
            destination.DocumentRegistrationDate = model.DocumentRegistrationDate;
            destination.DocumentRegistrationNumber = model.DocumentRegistrationNumber;
            destination.DocumentContent = model.DocumentContent;
            destination.Note = model.Note;
            
            return destination;
        }
    }
}
