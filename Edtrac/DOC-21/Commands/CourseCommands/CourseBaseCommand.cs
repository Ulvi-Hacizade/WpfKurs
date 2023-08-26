using DOC_21.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOC_21.Commands.CourseCommands
{

     public abstract class CourseBaseCommand : BaseCommand
    {
        protected readonly CourseViewModel viewModel;
        public CourseBaseCommand(CourseViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

    }
}
