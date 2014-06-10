// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="AddEntryPage.xaml.cs" project="RunnersTimeManagement.WP8" date="2014-06-07 22:14">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.Windows.Navigation;

    using RunnersTimeManagement.Core.Domain;
    using RunnersTimeManagement.WP8.Commands;

    public partial class AddEntryPage : BasePage
    {
        public TimeEntry TimeEntry { get; set; }

        public AddEntryPage()
        {
            TimeEntry = new TimeEntry();
            this.DataContext = this;
            this.InitializeComponent();

            this.uxAddButton.CommandParameter = TimeEntry;
            this.uxAddButton.Command = new AddTimeEntryCommand(this);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }
    }
}