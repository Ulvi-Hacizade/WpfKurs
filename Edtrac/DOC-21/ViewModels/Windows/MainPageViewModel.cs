using DOC_21.Commands.MainPageCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DOC_21.ViewModels.Windows
{
    public class MainPageViewModel : WindowViewModel
    {

        public  OpenOrganizationCommand OpenOrganization => new OpenOrganizationCommand(this);
        public OpenDocumentCommand OpenDocument => new OpenDocumentCommand(this);
        public OpenCourseCommand OpenCourse => new OpenCourseCommand(this);
        public Grid Grid { get; set; }
    }
}
