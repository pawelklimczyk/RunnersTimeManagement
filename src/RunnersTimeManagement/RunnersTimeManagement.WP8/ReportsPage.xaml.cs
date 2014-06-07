// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="ReportsPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-07 22:14">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Windows.Navigation;

    using Microsoft.Phone.Controls;

    public partial class ReportsPage : PhoneApplicationPage
    {
        private readonly AppBarBuilder appBarBuilder = new AppBarBuilder();

        public ReportsPage()
        {
            this.InitializeComponent();

            this.appBarBuilder.BuildAppBar(this);
            this.appBarBuilder.WireEvents();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.appBarBuilder.UnwireEvents();

            base.OnNavigatingFrom(e);
        }
    }
}