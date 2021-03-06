﻿// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="NavigateToNewAccountCommand.cs" project="RunnersTimeManagement.WP8" date="2014-06-04 11:41">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8.Commands
{
    using System;
    using System.Windows.Input;

    public class NavigateToNewAccountCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            PageRouter.Navigate(Page.CreateAccount);
        }

        public event EventHandler CanExecuteChanged;
    }
}
