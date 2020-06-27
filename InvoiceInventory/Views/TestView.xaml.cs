using Domain.Models.Rechnungen;
using InvoiceInventory.ViewModels;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Windows.Controls;

namespace InvoiceInventory.Views
{
    /// <summary>
    /// Interaction logic for TestView.xaml
    /// </summary>
    public partial class TestView : UserControl
    {

        TestViewModel twm;
        public TestView()
        {
            InitializeComponent();
            SyncfusionGrid.CurrentCellBeginEdit += SyncfusionGrid_CurrentCellBeginEdit;
            SyncfusionGrid.CurrentCellEndEdit += SyncfusionGrid_CurrentCellEndEdit;
            this.DataContextChanged += TestView_DataContextChanged;
          

        }

        private void TestView_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
          if(this.DataContext.GetType() == typeof(TestViewModel) )
            {
                
                twm = (TestViewModel)this.DataContext;
                twm.RefreshGrid += Twm_RefreshGrid;
            }
        }

        private void Twm_RefreshGrid()
        {
            if (twm != null)
            {
                SyncfusionGrid.View.Refresh();
            }
        }



        private void SyncfusionGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {

        }

        private void SyncfusionGrid_CurrentCellBeginEdit(object sender, CurrentCellBeginEditEventArgs e)
        {
            //var rowIndex = e.RowColumnIndex.RowIndex;

            ////If the rowindex in AddNewRowIndex, we need to validate whether the property is readonly or not.
            //if (this.SyncfusionGrid.IsAddNewIndex(rowIndex))
            //{
            //    //pdc - PropertyDescriptorCollection.
            //    var pdc = this.SyncfusionGrid.View.GetItemProperties();

            //    //get the propertyinfo from PropertyDescriptorCollection.
            //    var propertyInfo = pdc.Find(e.Column.MappingName, true);

            //    //property is readonly you can cancel the editing of the cell.
            //    if (propertyInfo.IsReadOnly)
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        private void SyncfusionGrid_AddNewRowInitiating(object sender, Syncfusion.UI.Xaml.Grid.AddNewRowInitiatingEventArgs e)
        {

            var data = e.NewObject as AusgangsRechnung;
            data.Datum = DateTime.Now;
            //data.RechnungsNummer = "AR-00-";



        }

        private void SyncfusionGrid_RowValidated(object sender, RowValidatedEventArgs e)
        {
            //var x = e.RowData as AusgangsrechnungBlank;
        }

        private void SyncfusionGrid_RowValidating(object sender, RowValidatingEventArgs e)
        {
            //var x = e.RowData as AusgangsrechnungBlank;
        }

        private void Aktualisieren_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SyncfusionGrid.View.Refresh();
        }
    }
}
