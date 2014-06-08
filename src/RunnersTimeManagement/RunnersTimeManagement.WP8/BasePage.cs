  // -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="BasePage.cs" project="RunnersTimeManagement.WP8" date="2014-06-08 14:32">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Windows.Controls;
    using System.Windows.Data;

    using Microsoft.Phone.Controls;

    public class BasePage : PhoneApplicationPage
    {
        internal void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Update the binding source
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);
            bindingExpr.UpdateSource();
        } 
    }
}
