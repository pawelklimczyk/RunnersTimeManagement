// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="MainPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-04 07:54">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Collections.Generic;
    using System.Windows.Navigation;

    using Microsoft.Phone.Controls;

    using RunnersTimeManagement.Core.Domain;

    public partial class MainPage : BasePage
    {
        private readonly AppBarBuilder appBarBuilder = new AppBarBuilder();

        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            this.appBarBuilder.BuildAppBar(this);
            this.appBarBuilder.WireEvents();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            FetchTimeEntries();
        }

        private async void FetchTimeEntries()
        {
            IsBusy = true;
            var operationStatus = await App.TimeService.GetTimeEntryList();
            List<TimeEntry> list = (List<TimeEntry>)operationStatus.Data;
            uxTimeEntries.ItemsSource = list;
            IsBusy = false;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.appBarBuilder.UnwireEvents();

            base.OnNavigatingFrom(e);
        }
    }
}