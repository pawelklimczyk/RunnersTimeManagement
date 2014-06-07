// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="PageRouter.cs" project="RunnersTimeManagement.WP8" date="2014-06-07 21:59">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System;

    public class PageRouter
    {
        private static Page currentPage;

        public static void Navigate(Page newPage)
        {
            if (currentPage != newPage)
            {
                currentPage = newPage;

                switch (newPage)
                {
                    case Page.Login:
                        App.RootFrame.Navigate(new Uri("/LoginPage.xaml", UriKind.Relative));
                        break;
                    case Page.CreateAccount:
                        App.RootFrame.Navigate(new Uri("/CreateAccountPage.xaml", UriKind.Relative));
                        break;
                    case Page.EntriesList:
                        App.RootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                        break;
                    case Page.AddEntry:
                        App.RootFrame.Navigate(new Uri("/AddEntryPage.xaml", UriKind.Relative));
                        break;
                    case Page.Reports:
                        App.RootFrame.Navigate(new Uri("/ReportsPage.xaml", UriKind.Relative));
                        break;
                    case Page.About:
                        App.RootFrame.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("newPage");
                }
            }
        }
    }

    public enum Page
    {
        Login,
        CreateAccount,
        EntriesList,
        AddEntry,
        Reports,
        About
    }

}