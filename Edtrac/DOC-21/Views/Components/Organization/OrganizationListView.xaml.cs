using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DOC_21.Views.Components.Organization
{
    /// <summary>
    /// Interaction logic for OrganizationListView.xaml
    /// </summary>
    public partial class OrganizationListView : UserControl
    {
        public OrganizationListView()
        {
            InitializeComponent();
        }

        private void MainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
