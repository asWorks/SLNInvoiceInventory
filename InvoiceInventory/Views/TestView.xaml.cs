using Domain.Models.Rechnungen;
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
        public TestView()
        {
            InitializeComponent();
            SyncfusionGrid.CurrentCellBeginEdit += SyncfusionGrid_CurrentCellBeginEdit;
            SyncfusionGrid.CurrentCellEndEdit += SyncfusionGrid_CurrentCellEndEdit;
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

            var data = e.NewObject as AusgangsrechnungBlank;
            data.Datum = DateTime.Now;
            data.RechnungsNummer = "AR-00-";



        }

        private void SyncfusionGrid_RowValidated(object sender, RowValidatedEventArgs e)
        {
            var x = e.RowData as AusgangsrechnungBlank;
        }

        private void SyncfusionGrid_RowValidating(object sender, RowValidatingEventArgs e)
        {
            var x = e.RowData as AusgangsrechnungBlank;
        }
    }
}
