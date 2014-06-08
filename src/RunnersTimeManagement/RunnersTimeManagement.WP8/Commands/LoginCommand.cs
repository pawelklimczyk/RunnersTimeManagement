// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="LoginCommand.cs" project="RunnersTimeManagement.WP8" date="2014-06-08 14:09">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8.Commands
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    using RunnersTimeManagement.Core.Domain;

    public class LoginUserCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            User user = parameter as User;

            if (user != null)
            {
                if (String.IsNullOrWhiteSpace(user.Username) || String.IsNullOrWhiteSpace(user.Password))
                {
                    MessageBox.Show("Please provide username and password");
                    return;
                }

                var operationStatus = await App.LoginService.LoginUser(user.Username, user.Password);

                if ((bool)operationStatus)
                {
                    PageRouter.Navigate(Page.EntriesList);
                }
                else
                {
                    MessageBox.Show(operationStatus.StatusDescription);
                }
            }
            else
            {
                MessageBox.Show("Internal error occured");
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}