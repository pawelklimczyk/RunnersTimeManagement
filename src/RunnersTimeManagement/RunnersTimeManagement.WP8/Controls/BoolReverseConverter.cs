// -------------------------------------------------------------------------------------------------------------------
// <copyright company="Gemotial" file="BoolReverseConverter.cs" project="RunnersTimeManagement.WP8" date="2014-06-09 23:47">
// 
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace RunnersTimeManagement.WP8.Controls
{
    using System;
    using System.Windows.Data;

    public class BoolReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
