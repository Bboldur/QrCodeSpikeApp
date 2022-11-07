using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace QrCodeWriterSpikeApp.Converters
{
    internal class MemoryStreamToImageSourceConverter : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var memorySteam = value as MemoryStream;
            if(memorySteam != null)
            {
                return ImageSource.FromStream(() => memorySteam);
            }
            return null;
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MemoryStream stream = (MemoryStream)((value as StreamImageSource)?.Stream(CancellationToken.None).GetAwaiter().GetResult());
            if (stream != null)
            {
                return stream;
            }
            return null;
        }
    }
}
