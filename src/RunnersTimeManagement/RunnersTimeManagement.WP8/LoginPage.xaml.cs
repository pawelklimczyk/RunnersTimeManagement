// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="LoginPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-04 08:37">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using Microsoft.Phone.Controls;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.WP8.Commands;

    public partial class LoginPage : BasePage
    {
        public User UserWithCredentialsToValidate { get; set; }

        public LoginPage()
        {
            UserWithCredentialsToValidate = new User();

            this.DataContext = UserWithCredentialsToValidate;
            this.InitializeComponent();

            this.uxCreateAccountButton.Command = new NavigateToNewAccountCommand();
            this.uxLoginButton.CommandParameter = UserWithCredentialsToValidate;
            this.uxLoginButton.Command = new LoginUserCommand();
        }
    }
}