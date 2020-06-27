using Caliburn.Micro;
using DalMySQL;
using Domain.Models.Rechnungen;
using InvoiceInventory.Interfaces;
using InvoiceInventory.ObjectCollections;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;

namespace InvoiceInventory.ViewModels

{
    [Export(typeof(ITestViewModel))]
    public class TestViewModel : Screen, ITestViewModel
    {

        public event System.Action RefreshGrid;
        #region "Fields"
        private readonly IEventAggregator _events;
        private InvoiceModel db = null;
        #endregion

        #region "Constructors"
        public TestViewModel()
        {
           
        }

        private ICommand rowDataCommand { get; set; }
        public ICommand RowDataCommand
        {
            get
            {
                return rowDataCommand;
            }
            set
            {
                rowDataCommand = value;
            }
        }

        [ImportingConstructor]
        public TestViewModel(IEventAggregator events)
        {
            _events = events;
            db = new InvoiceModel();
            rowDataCommand = new Helper.RelayCommand(ChangeCanExecute);


            isEditingAllowed = false;
            MonthToShow = new ObservableCollection<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            SelectedMonthToShow = DateTime.Now.Month;
            UpdateData();
        }

        #endregion

        #region "Properties"



        private Syncfusion.Data.CollectionViewAdv _sfView;
        public Syncfusion.Data.CollectionViewAdv sfView
        {
            get { return _sfView; }
            set
            {
                if (value != _sfView)
                {
                    _sfView = value;
                    NotifyOfPropertyChange(() => sfView);
                    //  isDirty = true;
                }
            }
        }

        private ContextAwareObservableCollection<AusgangsRechnung> _Items;
        public ContextAwareObservableCollection<AusgangsRechnung> Items
        {
            get { return _Items; }
            set
            {
                if (value != _Items)
                {
                    _Items = value;
                    NotifyOfPropertyChange(() => Items);
                    //  isDirty = true;
                }
            }
        }



        private AusgangsRechnung _SelectedItem;
        public AusgangsRechnung SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                if (value != _SelectedItem)
                {
                    _SelectedItem = value;
                    NotifyOfPropertyChange(() => SelectedItem);

                }
            }
        }



        private bool _isEditingAllowed;
        public bool isEditingAllowed
        {
            get { return _isEditingAllowed; }
            set
            {
                if (value != _isEditingAllowed)
                {
                    _isEditingAllowed = value;
                    NotifyOfPropertyChange(() => isEditingAllowed);
                    //  isDirty = true;
                }
            }
        }

        private ObservableCollection<int> _MonthToShow;
        public ObservableCollection<int> MonthToShow
        {
            get { return _MonthToShow; }
            set
            {
                if (value != _MonthToShow)
                {
                    _MonthToShow = value;
                    NotifyOfPropertyChange(() => MonthToShow);

                }
            }
        }

        private int _SelectedMonthToShow;
        public int SelectedMonthToShow
        {
            get { return _SelectedMonthToShow; }
            set
            {
                if (value != _SelectedMonthToShow)
                {
                    _SelectedMonthToShow = value;
                    NotifyOfPropertyChange(() => SelectedMonthToShow);
                    UpdateData();

                }
            }
        }




        #endregion

        #region "Methods"

        public void ChangeCanExecute(object obj)
        {
           
            
            var rowdataContent = (obj as AusgangsRechnung);

            rowdataContent.IstAusgebucht = true;
            // NotifyOfPropertyChange(() => SelectedItem);
            RefreshGrid?.Invoke();


            //MessageBox.Show("SelectedRow Details:\n" +
            //    "UserId -" + rowdataContent.UserId +
            //    "\nName -" + rowdataContent.Name +
            //    "\nDateofBirth -" + rowdataContent.DateofBirth +
            //    "\nContactNo -" + rowdataContent.ContactNo +
            //    "\nSalary -" + rowdataContent.Salary);
        }
        private void UpdateData()
        {
            IQueryable<AusgangsRechnung> data;

            if (SelectedMonthToShow == 0)
            {
                data = db.AusgangsRechnungen;
            }
            else
            {
                data = db.AusgangsRechnungen.Where(n => n.Datum.Month == SelectedMonthToShow);
            }


            Items = new ContextAwareObservableCollection<AusgangsRechnung>(data, db);
        }




        //public void Ausbuchen(object sender, System.Windows.RoutedEventArgs e)
        //{

        //}
        #endregion

        #region "CommandMethods"

        public void RefreshView()
        {
            //sfView.Refresh();
        }

        public void Save()
        {
            db.SaveChanges();

        }


        #endregion
    }
}
