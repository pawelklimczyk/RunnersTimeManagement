// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="AddEntryPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-07 22:14">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Windows.Navigation;

    using Microsoft.Phone.Controls;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.WP8.Commands;

    public partial class AddEntryPage : PhoneApplicationPage
    {
        private readonly AppBarBuilder appBarBuilder = new AppBarBuilder();

        public TimeEntry TimeEntry { get; set; }

        public AddEntryPage()
        {
            TimeEntry = new TimeEntry();
            this.DataContext = TimeEntry;
            this.InitializeComponent();

            this.appBarBuilder.BuildAppBar(this);
            this.appBarBuilder.WireEvents();
            
            this.uxAddButton.CommandParameter = TimeEntry;
            this.uxAddButton.Command = new AddTimeEntryCommand();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.appBarBuilder.UnwireEvents();

            base.OnNavigatingFrom(e);
        }
    }
}