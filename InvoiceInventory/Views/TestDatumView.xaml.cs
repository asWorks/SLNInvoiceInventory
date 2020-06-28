using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvoiceInventory.Views
{
    /// <summary>
    /// Interaction logic for TestDatumView.xaml
    /// </summary>
    public partial class TestDatumView : UserControl
    {
        public TestDatumView()
        {
            InitializeComponent();
        }

        private void Datum_UnderlyingDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var x = d;
            var y = e;
        }

        private void Datum_DateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var x = d;
            var y = e;
        }
    }
}
