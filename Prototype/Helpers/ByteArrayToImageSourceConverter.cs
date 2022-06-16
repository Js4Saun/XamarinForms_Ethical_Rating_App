using System;
using Xamarin.Forms;
using System.IO;
namespace Prototype.Helpers
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        #region IValueConverter implementation
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var bytes = (byte[])value;
                var retImageSource = ImageSource.FromStream(() => new MemoryStream(bytes));
                return retImageSource;
            }
            if (parameter != null)
            {
                var fillerIcon = (string)parameter;
                var retImageSource = ImageSource.FromFile(fillerIcon);
                return retImageSource;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotImplementedException();
        #endregion
    }
}
