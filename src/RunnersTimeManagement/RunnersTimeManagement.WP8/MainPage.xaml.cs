// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="MainPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-04 07:54">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Windows.Navigation;

    using Microsoft.Phone.Controls;

    public partial class MainPage : PhoneApplicationPage
    {
        private readonly AppBarBuilder appBarBuilder = new AppBarBuilder();

        public MainPage()
        {
            this.InitializeComponent();

            this.appBarBuilder.BuildAppBar(this);
            this.appBarBuilder.WireEvents();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //TODO
            //FetchTimeEntries();


        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.appBarBuilder.UnwireEvents();

            base.OnNavigatingFrom(e);
        }
    }
}