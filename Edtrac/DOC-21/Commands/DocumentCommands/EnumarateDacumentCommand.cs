using DOC_21.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DOC_21.Commands.DocumentCommands
{
    public class EnumarateDocumentCommand:DocumentBaseCommand
    {
        public EnumarateDocumentCommand(DocumentViewModel viewModel) : base(viewModel)
        {

        }
        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.Documents)
            {
                item.No = no;
                no++;
            }
        }
    }
}
