// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="SearchCommand.cs" project="RunnersTimeManagement.WP8" date="2014-06-13 23:45">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------
namespace RunnersTimeManagement.WP8.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;

    using RunnersTimeManagement.Core.Domain;

    public class SearchCommand : ICommand
    {
        private readonly MainPage basePage;

        public SearchCommand(MainPage basePage)
        {
            this.basePage = basePage;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            TimeEntryFilter filter = parameter as TimeEntryFilter;

            if (filter != null)
            {
                OperationStatus validationStatus = filter.Validate();

                if (!(bool)validationStatus)
                {
                    MessageBox.Show(validationStatus.StatusDescription);
                }
                else
                {
                    basePage.IsBusy = true;
                    var operationStatus = await App.TimeService.GetTimeEntryList(filter);

                    if ((bool)operationStatus)
                    {
                        List<TimeEntry> list = (List<TimeEntry>)operationStatus.Data;
                        basePage.uxTimeEntries.ItemsSource = list;
                    }
                    else
                    {
                        MessageBox.Show(operationStatus.StatusDescription);
                    }
                    basePage.IsBusy = false;
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}