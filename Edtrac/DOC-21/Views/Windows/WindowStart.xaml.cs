using DOC_21.Util;
using DOC_21.ViewModels.Windows;
using DOC_21Core.Configurations;
using DOC_21Core.Factories;
using DOC_21Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Constants = DOC_21Core.Utils.Constants;

namespace DOC_21.Views.Windows
{
    /// <summary>
    /// Interaction logic for WindowStart.xaml
    /// </summary>
    public partial class WindowStart : Window
    {
        // called before window loading
        public WindowStart()
        {
            InitializeComponent();
            // shouldn't write any heavy (even simple) logic in constructor
        }

        // called after window loading
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckServer();
        }

        private async void CheckServer()
        {
            bool exists = IOUtil.ConfigurationFileExist(Constants.ConfigurationFilePath);
            if (exists)
            {
                string content = IOUtil.ReadFile(Constants.ConfigurationFilePath);
                ConfigObject config = JsonConvert.DeserializeObject<ConfigObject>(content);
                if (!config.IsWindowsAuthentication)
                {
                    config.Password = SecurityUtil.Decrypt(config.Password);
                }
                string connString = UnitOfWorkFactory.CreateConnString(config.ServerName, config.DatabaseName, config.UserId, config.Password, config.IsWindowsAuthentication);
                Kernel.Db = UnitOfWorkFactory.Create(connString, config.SqlServerType);
                bool isOnline = Kernel.Db.CheckServer();

                if (isOnline)
                {
                    // go to login page
                    //await Task.Delay(2500);

                    LoginViewModel viewModel = new LoginViewModel();
                    LoginPage loginPage = new LoginPage();
                    viewModel.Window = loginPage;
                    loginPage.DataContext = viewModel;
                    this.Close();
                    loginPage.Show();
                }
                else
                {
                    OpenConfigurationPage();
                }
            }
            else
            {
                OpenConfigurationPage();
            }
        }


        private void OpenConfigurationPage()
        {
            SqlConfigurationViewModel viewModel = new SqlConfigurationViewModel();
            SqlConfiguration configWindow = new SqlConfiguration();
            viewModel.Window = configWindow;
            configWindow.DataContext = viewModel;
            this.Close();
            configWindow.Show();
        }

        
    }
}
