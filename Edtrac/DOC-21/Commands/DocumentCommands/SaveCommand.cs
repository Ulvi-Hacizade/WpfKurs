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

namespace DOC_21.Commands.DocumentCommands
{
    public class SaveCommand : DocumentBaseCommand
    {
        public SaveCommand(DocumentViewModel viewModel) : base(viewModel)
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
                        var document = DocumentMapper.Map(viewModel.CurrentDocument, new Document());
                        document.IsDeleted = false;
                        document.CreationDate = DateTime.Now;
                        document.Creator = Kernel.AuthenticatedUser;

                        DB.DocumentRepository.Add(document);
                    }
                    else if (situation == (int)Constants.SITUATIONS.EDIT)
                    {
                        int id = viewModel.CurrentDocument.Id;
                        var existingDocument = DB.DocumentRepository.FindById(id);
                        if (existingDocument != null)
                        {
                            existingDocument = DocumentMapper.Map(viewModel.CurrentDocument, existingDocument);
                            existingDocument.CreationDate = DateTime.Now;
                            existingDocument.Creator = Kernel.AuthenticatedUser;
                            DB.DocumentRepository.Update(existingDocument);
                        }
                    }

                    viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                    BusinessUtil.DoAnimation(viewModel.MessageDialog);

                    // reload all documents

                    List<Document> documents = DB.DocumentRepository.Get();
                    List<DocumentModel> models = new List<DocumentModel>();
                    foreach (var document in documents)
                    {
                        var model = DocumentMapper.Map(document);
                        models.Add(model);
                    }
                    viewModel.AllDocuments = new List<DocumentModel>(models);

                    viewModel.SelectedDocument = null;
                    viewModel.InitializeViewModel();
                }
            }
        }
       
        private bool IsValid()
        {
            var document = viewModel.CurrentDocument;

            if (string.IsNullOrEmpty(document.DocumentName))
            {
                MessageBox.Show("Müraciətin adı mütləq daxil edilməlidir!");
                return false;
            }

            if (string.IsNullOrEmpty(document.DocumentCreator))
            {
                MessageBox.Show("Müraciəti tərtib edən  əməkdaşın adı və soyadı mütləq daxil edilməlidir!");
                return false;
            }

            if (string.IsNullOrEmpty(document.DocumentRegistrationNumber))
            {
                MessageBox.Show("Müraciətin qeydiyyat nömrəsi mütləq daxil edilməlidir!");
                return false;
            }

            if (string.IsNullOrEmpty(document.DocumentContent))
            {
                MessageBox.Show("Müraciətin məzmunu mütləq daxil edilməlidir!");
                return false;
            }

            return true;
        }

        private void CorrectData()
        {
            if (viewModel.CurrentDocument.DocumentName != null)
            {
                viewModel.CurrentDocument.DocumentName = viewModel.CurrentDocument.DocumentName.Trim();
            }

            if (viewModel.CurrentDocument.DocumentCreator != null)
            {
                viewModel.CurrentDocument.DocumentCreator = viewModel.CurrentDocument.DocumentCreator.Trim();
            }

            if (viewModel.CurrentDocument.DocumentRegistrationNumber != null)
            {
                viewModel.CurrentDocument.DocumentRegistrationNumber = viewModel.CurrentDocument.DocumentRegistrationNumber.Trim();
            }

            



            if (viewModel.CurrentDocument.Note != null)
            {
                viewModel.CurrentDocument.Note = viewModel.CurrentDocument.Note.Trim();
            }

            

        }
    }
}
