// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="CreateAccountPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-04 11:38">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using Microsoft.Phone.Controls;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.WP8.Commands;

    public partial class CreateAccountPage : PhoneApplicationPage
    {
        public UserWith2Passwords UserWithCredentialsToValidate { get; set; }

        public CreateAccountPage()
        {
            UserWithCredentialsToValidate = new UserWith2Passwords();

            this.DataContext = UserWithCredentialsToValidate;
            this.InitializeComponent();

            this.uxCreateAccountButton.CommandParameter = UserWithCredentialsToValidate;
            this.uxCreateAccountButton.Command = new CreateNewAccountCommand();
        }
    }

    public class UserWith2Passwords : User
    {
        public string PasswordRetype { get; set; }
    }

}