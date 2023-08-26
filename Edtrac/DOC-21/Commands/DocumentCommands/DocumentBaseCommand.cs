using DOC_21.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.DocumentCommands
{

      public abstract class DocumentBaseCommand : BaseCommand
    {
        protected readonly DocumentViewModel viewModel;
        public DocumentBaseCommand(DocumentViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

    }
}
