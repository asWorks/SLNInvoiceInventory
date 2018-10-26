using Caliburn.Micro;
using System.Linq;
using DalMySQL;
using Domain.Models.Rechnungen;
using InvoiceInventory.Interfaces;
using InvoiceInventory.ObjectCollections;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Data.Entity;

namespace InvoiceInventory.ViewModels

{
    [Export(typeof(ITestViewModel))]
    public class TestViewModel : Screen, ITestViewModel
    {

        private readonly IEventAggregator _events;
        private InvoiceModel db = null;

        public TestViewModel()
        {

        }



        [ImportingConstructor]
        public TestViewModel(IEventAggregator events)
        {
            _events = events;
            db = new InvoiceModel();


            var data = db.AusgangsRechnungen.OrderBy(n => n.RechnungsId);
            Items = new ContextAwareObservableCollection<Domain.Models.Rechnungen.AusgangsRechnung>(data,db);
            isEditingAllowed = false;

        }

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


        #endregion

        #region "CommandMethods"

        public void Save()
        {
            db.SaveChanges();
        }


        #endregion
    }
}
