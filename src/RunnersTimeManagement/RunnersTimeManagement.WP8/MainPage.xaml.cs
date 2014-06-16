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
    using RunnersTimeManagement.WP8.Commands;

    public partial class MainPage : BasePage
    {
        public TimeEntryFilter Filter { get; set; }
        public SearchCommand SearchCommand { get; set; }

        public MainPage()
        {
            Filter= new TimeEntryFilter();
            SearchCommand = new SearchCommand(this);
            
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
            SearchCommand.Execute(Filter);
            //IsBusy = true;
            //var operationStatus = await App.TimeService.GetTimeEntryList(Filter);
            //List<TimeEntry> list = (List<TimeEntry>)operationStatus.Data;
            //uxTimeEntries.ItemsSource = list;
            //IsBusy = false;
        }
    }
}