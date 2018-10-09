using Caliburn.Micro;
using DalMySQL;
using Domain.Models.Rechnungen;
using InvoiceInventory.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace InvoiceInventory.ViewModels

{
    [Export(typeof(ITestViewModel))]
    public class TestViewModel : Screen, ITestViewModel
    {

        private readonly IEventAggregator _events;
        private InvoiceModel db = null;





        [ImportingConstructor]
        public TestViewModel(IEventAggregator events)
        {
            _events = events;
            db = new InvoiceModel();
            var data = db.AusgangsRechnungen;
            Items = new ObservableCollection<Domain.Models.Rechnungen.AusgangsRechnung>(data);
            isEditingAllowed = true;

        }

        #region "Properties"
        private ObservableCollection<AusgangsRechnung> _Items;
        public ObservableCollection<AusgangsRechnung> Items
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
