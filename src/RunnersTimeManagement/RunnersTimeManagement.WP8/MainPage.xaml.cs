// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="MainPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-04 07:54">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using Microsoft.Phone.Controls;

    public partial class MainPage : PhoneApplicationPage
    {
        private AppBarBuilder appBarBuilder;

        public MainPage()
        {
            this.InitializeComponent();

            appBarBuilder.BuildAppBar(this);
            appBarBuilder.WireEvents();
        }

        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            appBarBuilder.UnwireEvents();

            base.OnNavigatingFrom(e);
        }
    }
}