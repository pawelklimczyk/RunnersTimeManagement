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

    public class CreateNewAccountCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            UserWith2Passwords user = parameter as UserWith2Passwords;

            if (user != null)
            {
                if (String.IsNullOrWhiteSpace(user.Username) || String.IsNullOrWhiteSpace(user.Password))
                {
                    MessageBox.Show("Please provide username and password");
                    return;
                }

                if (user.Password != user.PasswordRetype)
                {
                    MessageBox.Show("Passwords does not match");
                    return;
                }

                var operationStatus = await App.LoginService.CreateUser(user.Username, user.Password);

                if ((bool)operationStatus)
                {
                    var loginCommand = new LoginUserCommand();
                    loginCommand.Execute(new User() { Username = user.Username, Password = user.Password });
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