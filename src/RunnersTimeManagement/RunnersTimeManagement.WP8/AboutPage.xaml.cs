// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="AboutPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-07 22:14">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Windows.Navigation;

    using Microsoft.Phone.Controls;

    public partial class AboutPage : BasePage
    {
        private readonly AppBarBuilder appBarBuilder = new AppBarBuilder();

        public AboutPage()
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