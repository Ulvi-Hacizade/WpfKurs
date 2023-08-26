using DOC_21.Mappers;
using DOC_21.Models;
using DOC_21.ViewModels.UserControls;
using DOC_21.ViewModels.Windows;
using DOC_21.Views.UserControls;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.MainPageCommands
{

    public class OpenDocumentCommand : MainPageBaseCommand
    {
        public OpenDocumentCommand(MainPageViewModel viewModel) : base(viewModel)
        {
        }

        public override void Execute(object parameter)
        {
            DocumentControl documentControl = new DocumentControl();

            DocumentViewModel documentViewModel = new DocumentViewModel();
            documentViewModel.MessageDialog = documentControl.MessageDialog;
            documentViewModel.ComponentsSize = "*";
            documentViewModel.Row3Size = "auto";

            List<Document> documents = DB.DocumentRepository.Get();
            List<DocumentModel> models = new List<DocumentModel>();
            foreach (var document in documents)
            {
                var model = DocumentMapper.Map(document);
                models.Add(model);
            }
            documentViewModel.AllDocuments = new List<DocumentModel>(models);

            documentViewModel.InitializeViewModel();
            documentControl.DataContext = documentViewModel;
            documentViewModel.Grid = documentControl.grdComponents1;
            documentViewModel.GridListView = documentControl.grdListView;



            viewModel.Grid.Children.Clear();
            viewModel.Grid.Children.Add(documentControl);
        }
    }
}
