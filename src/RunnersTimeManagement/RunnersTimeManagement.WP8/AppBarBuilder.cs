// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="AppBarBuilder.cs" project="RunnersTimeManagement.WP8" date="2014-06-07 21:44">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System;

    using Microsoft.Phone.Controls;
    using Microsoft.Phone.Shell;

    public class AppBarBuilder
    {
        public void BuildAppBar(PhoneApplicationPage page)
        {
            page.ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton addTimeEntryButton = new ApplicationBarIconButton(new Uri("/Assets/application_bar_add.png", UriKind.Relative));
            addTimeEntryButton.Text = "Add";
            page.ApplicationBar.Buttons.Add(addTimeEntryButton);
            
            ApplicationBarIconButton showListButton = new ApplicationBarIconButton(new Uri("/Assets/application_bar_list.png", UriKind.Relative));
            showListButton.Text = "List";
            page.ApplicationBar.Buttons.Add(showListButton);
            
            ApplicationBarIconButton showReportsButton = new ApplicationBarIconButton(new Uri("/Assets/application_bar_reports.png", UriKind.Relative));
            showReportsButton.Text = "Reports";
            page.ApplicationBar.Buttons.Add(showReportsButton);

            ApplicationBarMenuItem aboutButton = new ApplicationBarMenuItem("About");
            page.ApplicationBar.MenuItems.Add(aboutButton);
        }
        
        public void WireEvents()
        {
        }

        public void UnwireEvents()
        {
        }
    }
}