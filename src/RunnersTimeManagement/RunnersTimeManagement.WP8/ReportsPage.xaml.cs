// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ReportsPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-07 22:14">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Collections.Generic;
    using System.Windows.Navigation;

    using RunnersTimeManagement.Core.Domain;

    public partial class ReportsPage : BasePage
    {
        public ReportsPage()
        {
            this.DataContext = this;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.FetchReports();
        }

        private async void FetchReports()
        {
            IsBusy = true;
            var operationStatus = await App.ReportsService.GetWeeklyReports();
            List<WeeklyReport> list = (List<WeeklyReport>)operationStatus.Data;
            uxReports.ItemsSource = list;
            IsBusy = false;
        }
    }
}