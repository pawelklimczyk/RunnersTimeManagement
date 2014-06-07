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
        private ApplicationBarIconButton addTimeEntryButton;
        private ApplicationBarIconButton showListButton;
        private ApplicationBarIconButton showReportsButton;
        private ApplicationBarMenuItem aboutButton;

        public void BuildAppBar(PhoneApplicationPage page)
        {
            page.ApplicationBar = new ApplicationBar();

            addTimeEntryButton = new ApplicationBarIconButton(new Uri("/Assets/application_bar_add.png", UriKind.Relative));
            addTimeEntryButton.Text = "Add";
            page.ApplicationBar.Buttons.Add(addTimeEntryButton);

            showListButton = new ApplicationBarIconButton(new Uri("/Assets/application_bar_list.png", UriKind.Relative));
            showListButton.Text = "List";
            page.ApplicationBar.Buttons.Add(showListButton);

            showReportsButton = new ApplicationBarIconButton(new Uri("/Assets/application_bar_reports.png", UriKind.Relative));
            showReportsButton.Text = "Reports";
            page.ApplicationBar.Buttons.Add(showReportsButton);

            aboutButton = new ApplicationBarMenuItem("About");
            page.ApplicationBar.MenuItems.Add(aboutButton);
        }

        public void WireEvents()
        {
            addTimeEntryButton.Click += addTimeEntryButton_Click;
            showListButton.Click += showListButton_Click;
            showReportsButton.Click += showReportsButton_Click;
            aboutButton.Click += aboutButton_Click;
        }

        public void UnwireEvents()
        {
            addTimeEntryButton.Click -= addTimeEntryButton_Click;
            showListButton.Click -= showListButton_Click;
            showReportsButton.Click -= showReportsButton_Click;
            aboutButton.Click -= aboutButton_Click;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            PageRouter.Navigate(Page.About);
        }

        private void showReportsButton_Click(object sender, EventArgs e)
        {
            PageRouter.Navigate(Page.Reports);
        }

        private void showListButton_Click(object sender, EventArgs e)
        {
            PageRouter.Navigate(Page.EntriesList);
        }

        private void addTimeEntryButton_Click(object sender, EventArgs e)
        {
            PageRouter.Navigate(Page.AddEntry);
        }
    }
}