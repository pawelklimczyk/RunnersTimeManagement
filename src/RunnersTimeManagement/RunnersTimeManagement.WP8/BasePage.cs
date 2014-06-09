// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="BasePage.cs" project="RunnersTimeManagement.WP8" date="2014-06-08 14:32">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8
{
    using System.ComponentModel;

    using Microsoft.Phone.Controls;

    public class BasePage : PhoneApplicationPage, INotifyPropertyChanged
    {
        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    this.OnPropertyChanged("IsBusy");
                }
            }
        }
        public string Message { get; set; }

        public BasePage()
        {
            Message = "Working";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
