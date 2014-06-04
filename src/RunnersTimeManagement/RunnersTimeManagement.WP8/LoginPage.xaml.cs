// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="LoginPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-04 08:37">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using Microsoft.Phone.Controls;

    using RunnersTimeManagement.WP8.Commands;

    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            this.InitializeComponent();

            this.uxCreateAccountButton.Command = new NavigateToNewAccountCommand();
        }
    }
}