using Contracts.Domain.Interfaces;
using System;
using System.Globalization;
using System.Windows.Data;

namespace InvoiceInventory.Converters
{
    internal class DateTime2MonthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var v = (IInvoice)value;
                //if (v.Datum.HasValue)
                //{
                //    return v.Datum.Value.Month;
                //}

                ////return 0;

                return v.Datum.Month;

            }
            catch (Exception)
            {

                return 0;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
