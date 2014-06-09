// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="AddTimeEntryCommand.cs" project="RunnersTimeManagement.WP8" date="2014-06-09 11:49">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8.Commands
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    using RunnersTimeManagement.Core.Domain;

    public class AddTimeEntryCommand : ICommand
    {
        private readonly BasePage basePage;

        public AddTimeEntryCommand(BasePage basePage)
        {
            this.basePage = basePage;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            TimeEntry timeEntry = parameter as TimeEntry;

            if (timeEntry != null)
            {
                if (timeEntry.Distance <= 0 || timeEntry.EntryDate == DateTime.MinValue || timeEntry.TimeElapsed <= 0)
                {
                    MessageBox.Show("Please provide date, distance and time elapsed");
                    return;
                }
                this.basePage.IsBusy = true;    
                var operationStatus = await App.TimeService.AddTimeEntry(timeEntry);
                this.basePage.IsBusy = false;

                MessageBox.Show(operationStatus.StatusDescription);
            }
            else
            {
                MessageBox.Show("Internal error occured");
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
