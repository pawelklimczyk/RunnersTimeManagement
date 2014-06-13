// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="MainPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-04 07:54">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Collections.Generic;
    using System.Windows.Navigation;

    using RunnersTimeManagement.Core.Domain;

    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.NavigationMode == NavigationMode.New)
            {
                FetchTimeEntries();
            }
        }

        private async void FetchTimeEntries()
        {
            IsBusy = true;
            var operationStatus = await App.TimeService.GetTimeEntryList();
            List<TimeEntry> list = (List<TimeEntry>)operationStatus.Data;
            uxTimeEntries.ItemsSource = list;
            IsBusy = false;
        }
    }
}