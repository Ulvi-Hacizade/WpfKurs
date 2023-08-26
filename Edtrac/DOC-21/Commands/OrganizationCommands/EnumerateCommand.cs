using DOC_21.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.OrganizationCommands
{
    public class EnumerateCommand : OrganizationBaseCommand
    {
        public EnumerateCommand(OrganizationViewModel viewModel) : base(viewModel)
        {

        }

        public override void Execute(object parameter)
        {
            int no = 1;
            foreach (var item in viewModel.Organizations)
            {
                item.No = no;
                no++;
            }
        }
    }
}
