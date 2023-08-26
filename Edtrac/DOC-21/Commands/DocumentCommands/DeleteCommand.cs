using DOC_21.Mappers;
using DOC_21.Models;
using DOC_21.Util;
using DOC_21.ViewModels;
using DOC_21.ViewModels.UserControls;
using DOC_21.Views.Components;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.DocumentCommands
{
    public class DeleteCommand : DocumentBaseCommand
    {

        public DeleteCommand(DocumentViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            DialogViewModel dialogViewModel = new DialogViewModel();
            dialogViewModel.DialogText = "Silmək istədiyinizdən əminsinizmi?";

            Dialog dialog = new Dialog();
            dialog.DataContext = dialogViewModel;
            if (dialog.ShowDialog() == true)
            {
                int id = viewModel.SelectedDocument.Id;
                var document = DB.DocumentRepository.FindById(id);
                if (document != null)
                {
                    document.IsDeleted = true;
                    DB.DocumentRepository.Update(document);
                }

                viewModel.Message = "Əməliyyat uğurla həyata keçdi";
                BusinessUtil.DoAnimation(viewModel.MessageDialog);

                // reload all branches
                List<Document> documents = DB.DocumentRepository.Get();
                List<DocumentModel> models = new List<DocumentModel>();
                foreach (var documen in documents)
                {
                    var model = DocumentMapper.Map(documen);
                    models.Add(model);
                }
                viewModel.AllDocuments = new List<DocumentModel>(models);

                viewModel.InitializeViewModel();
            }
        }
    }
}
