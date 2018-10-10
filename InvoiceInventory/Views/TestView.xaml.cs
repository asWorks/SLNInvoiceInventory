using Domain.Models.Rechnungen;
using System;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.UI.Xaml.Grid;

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
            throw new NotImplementedException();
        }

        private void SyncfusionGrid_CurrentCellBeginEdit(object sender, CurrentCellBeginEditEventArgs e)
        {
            var rowIndex = e.RowColumnIndex.RowIndex;

            //If the rowindex in AddNewRowIndex, we need to validate whether the property is readonly or not.
            if (this.SyncfusionGrid.IsAddNewIndex(rowIndex))
            {
                //pdc - PropertyDescriptorCollection.
                var pdc = this.SyncfusionGrid.View.GetItemProperties();

                //get the propertyinfo from PropertyDescriptorCollection.
                var propertyInfo = pdc.Find(e.Column.MappingName, true);

                //property is readonly you can cancel the editing of the cell.
                if (propertyInfo.IsReadOnly)
                {
                    e.Cancel = true;
                }
            }
        }

        private void SyncfusionGrid_AddNewRowInitiating(object sender, Syncfusion.UI.Xaml.Grid.AddNewRowInitiatingEventArgs e)
        {



            var x = new AusgangsRechnung(DateTime.Now, "qwertz_asdfgh");

            //x.Ausbuchen(new BuchungsReference(x, DateTime.Now, "Non2"));
            //x.Storno(new StornoReference(x, DateTime.Now, "None", 24));
            x.Zuzahlung = 11.11M;
            x.Netto = 12.12M;
            x.Umsatzsteuer = 1;


            e.NewObject = x;

            ////if (this.SyncfusionGrid.View.IsAddingNew)
            ////{

            ////    if (this.SyncfusionGrid.SelectionController.CurrentCellManager.CurrentCell.IsEditing)
            ////        this.SyncfusionGrid.SelectionController.CurrentCellManager.EndEdit(true);

            ////   var rowColumnIndex = this.SyncfusionGrid.SelectionController.CurrentCellManager.CurrentRowColumnIndex;

            ////    //Process the commit operation in AddNewRow.
            ////    var addNewRowController = this.SyncfusionGrid.GetAddNewRowController();
            ////    addNewRowController.CommitAddNew();

            ////    //Gets the row index of AddNewRow 
            ////    rowColumnIndex.RowIndex = addNewRowController.GetAddNewRowIndex();
            ////    this.SyncfusionGrid.SelectedItems.Clear();

            ////    //If the AddNewRowPosition is Top need to move the current cell to next row 
            ////    if (this.SyncfusionGrid.AddNewRowPosition == AddNewRowPosition.Top)
            ////        rowColumnIndex.RowIndex = rowColumnIndex.RowIndex + 1;

            ////    //Which retains the current cell border in the row after canceling AddNewRow as you press ESC key operation.
            ////    this.SyncfusionGrid.MoveCurrentCell(rowColumnIndex);
            ////}

        }


    }
}
