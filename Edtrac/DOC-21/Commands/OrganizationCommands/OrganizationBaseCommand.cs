using DOC_21.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.OrganizationCommands
{
    
    public abstract class OrganizationBaseCommand : BaseCommand
    {
        protected readonly OrganizationViewModel viewModel;
        public OrganizationBaseCommand(OrganizationViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

    }
}
