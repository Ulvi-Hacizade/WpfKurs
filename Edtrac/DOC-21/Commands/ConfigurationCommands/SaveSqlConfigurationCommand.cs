using DOC_21.ViewModels.Windows;
using DOC_21Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DOC_21.Commands.ConfigurationCommands
{
    public class SaveSqlConfigurationCommand : BaseCommand
    {
        private readonly SqlConfigurationViewModel viewModel;
        public SaveSqlConfigurationCommand(SqlConfigurationViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override bool CanExecute(object parameter)
        {
            //if(string.IsNullOrEmpty(viewModel.ConfigObject.ServerName))
            //{
            //    return false;
            //}

            //if(string.IsNullOrEmpty(viewModel.ConfigObject.DatabaseName))
            //{
            //    return false;
            //}

            //if(!viewModel.ConfigObject.IsWindowsAuthentication)
            //{
            //    if(string.IsNullOrEmpty(viewModel.ConfigObject.UserId))
            //    {
            //        return false;
            //    }

            //    PasswordBox pwBox = (PasswordBox)parameter;
            //    string password = pwBox.Password;
            //    if(string.IsNullOrEmpty(password))
            //    {
            //        return false;
            //    }
            //}

            return true;
        }

        public override void Execute(object parameter)
        {
            if (viewModel.ConfigObject.IsWindowsAuthentication)
            {
                viewModel.ConfigObject.UserId = null;
                viewModel.ConfigObject.Password = null;
            }
            else
            {
                if (string.IsNullOrEmpty(viewModel.ConfigObject.UserId))
                {
                    MessageBox.Show("Please enter UserId field.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                PasswordBox passwordBox = (PasswordBox)parameter;
                string password = passwordBox.Password;
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter Password field.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                viewModel.ConfigObject.Password = SecurityUtil.Encrypt(password);
            }
            string json = JsonConvert.SerializeObject(viewModel.ConfigObject);
            IOUtil.WriteFile(Constants.ConfigurationFilePath, json);
            viewModel.Window.Close();
        }

    }
}
