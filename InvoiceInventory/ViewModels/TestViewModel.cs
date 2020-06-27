using Caliburn.Micro;
using DalMySQL;
using Domain.Models.Rechnungen;
using InvoiceInventory.Interfaces;
using InvoiceInventory.ObjectCollections;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;

namespace InvoiceInventory.ViewModels

{
    [Export(typeof(ITestViewModel))]
    public class TestViewModel : Screen, ITestViewModel
    {

        #region "Fields"
        private readonly IEventAggregator _events;
        private InvoiceModel db = null;
        #endregion

        #region "Constructors"
        public TestViewModel()
        {

        }



        [ImportingConstructor]
        public TestViewModel(IEventAggregator events)
        {
            _events = events;
            db = new InvoiceModel();


            isEditingAllowed = false;
            MonthToShow = new ObservableCollection<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            SelectedMonthToShow = DateTime.Now.Month;
            UpdateData();
        }

        #endregion

        #region "Properties"
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
        private void UpdateData()
        {
            //var data = db.AusgangsRechnungen.Where(n => n.Datum.Month == SelectedMonthToShow);
            ////var data = db.AusgangsRechnungen;

            //Items = new ContextAwareObservableCollection<AusgangsRechnung>(data, db);

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
        #endregion

        #region "CommandMethods"

        public void Save()
        {
            db.SaveChanges();
        }


        #endregion
    }
}
