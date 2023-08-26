using DOC_21.Commands.DocumentCommands;
using DOC_21.Models;
using DOC_21.Util;
using DOC_21.ViewModels.Windows;
using DOC_21.Views.Components.Document;
using DOC_21Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DOC_21.ViewModels.UserControls
{
   
    public class DocumentViewModel : UCViewModel
    {
        double height { get; set; } = SystemParameters.WorkArea.Height;

        public double Height
        {
            get => height;
            set
            {
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        string row3Size { get; set; }
        public string Row3Size
        {
            get => row3Size;
            set
            {
                row3Size = value;
                OnPropertyChanged(nameof(Row3Size));
            }
        }

        string componentsSize { get; set; }
        public string ComponentsSize
        {
            get => componentsSize;
            set
            {
                componentsSize = value;
                OnPropertyChanged(nameof(ComponentsSize));
            }
        }
        public Grid Grid { get; set; }
        public Grid GridListView { get; set; }

        public MainPageViewModel MainPageViewModel { get; set; }
        public void InitializeViewModel()
        {

            CurrentDocument = new DocumentModel();
            CurrentSituation = (int)Constants.SITUATIONS.NORMAL;


            Enumerate.Execute(null);
            
            SelectedDocument = null;

            Header = "Müraciətlər";

            Documents = new List<DocumentModel>(AllDocuments);
        }



        private DocumentModel searcTextDocument;
        public DocumentModel SearchTextDocument
        {

            get
            {


                if (searcTextDocument != null)
                {

                    Documents = AllDocuments.Where(x => x.Contains(searcTextDocument, "DocumentName") &&
                    x.Contains(searcTextDocument, "DocumentCreator") &&
                    x.Contains(searcTextDocument, "DocumentRegistrationNumber") &&
                    x.Contains(searcTextDocument, "DocumentContent") &&
                    x.Contains(searcTextDocument, "Note") &&
                    x.Contains(searcTextDocument, "SearchBeginDate") &&
                    x.Contains(searcTextDocument, "SearchEndDate")).ToList();

                    Enumerate.Execute(null);
                }
                else
                {

                    searcTextDocument = new DocumentModel();
                }


                return searcTextDocument;

            }

        }

        public List<DocumentModel> AllDocuments;

        public SearchCommand Search => new SearchCommand(this);
       public RejectCommand Reject => new RejectCommand(this);
        public SaveCommand Save => new SaveCommand(this);
        public EnumarateDocumentCommand Enumerate => new EnumarateDocumentCommand(this);
        public DeleteCommand Delete => new DeleteCommand(this);



        private DocumentModel currentDocument;
        public DocumentModel CurrentDocument
        {
            get => currentDocument;
            set
            {

                currentDocument = value;
                OnPropertyChanged(nameof(CurrentDocument));
            }
        }

        private List<DocumentModel> documents;
        public List<DocumentModel> Documents
        {
            get => documents ?? (documents = new List<DocumentModel>());
            set
            {
                documents = value;
                OnPropertyChanged(nameof(Documents));
            }
        }

        private DocumentModel selectedDocument;
        public DocumentModel SelectedDocument
        {
            get => selectedDocument;
            set
            {
                selectedDocument = value;
                if (value != null)
                {
                    MainGridDocument mainGrid = new MainGridDocument();
                    
                    Grid.Children.Clear();
                    Grid.Children.Add(mainGrid);
                    GridListView.Children.Clear();
                    ComponentsSize = "*";
                    Row3Size = "auto";
                    CurrentDocument = SelectedDocument;
                    CurrentSituation = (int)Constants.SITUATIONS.SELECTED;

                }
                OnPropertyChanged(nameof(SelectedDocument));
            }
        }
    }
}
