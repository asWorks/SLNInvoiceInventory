using Caliburn.Micro;
using DalMySQL;
using InvoiceInventory.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Domain.Models.Rechnungen;

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
        }

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



    }
}
