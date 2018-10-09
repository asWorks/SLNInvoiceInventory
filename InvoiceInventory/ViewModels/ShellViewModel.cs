using Caliburn.Micro;
using InvoiceInventory.Events;
using InvoiceInventory.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace InvoiceInventory.ViewModels
{

    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : Conductor<object>, IShellViewModel, IHandle<Events.EventMessage>
    {



        private readonly IEventAggregator _events;
        private ITestViewModel _testViewModel;
        private IAddAusgangsrechnungViewModel _addAusgangsRechnungViewModel;
        private IAddEingangsrechnungViewModel _addEingangsRechnungViewModel;

        public ShellViewModel()
        {



        }

        [ImportingConstructor]
        public ShellViewModel(ITestViewModel testVM,IAddAusgangsrechnungViewModel AddAusgangsRechnungVM, IAddEingangsrechnungViewModel AddEingangsRechnungVM, IEventAggregator events)
        {
            _events = events;
            _testViewModel = testVM;
            _addAusgangsRechnungViewModel = AddAusgangsRechnungVM;
            _addEingangsRechnungViewModel = AddEingangsRechnungVM;
            events.Subscribe(this);

        }





        public void Test()
        {
            ActivateItem(_testViewModel);
        }

        public void AddAusgangsRechnung()
        {
            ActivateItem(_addAusgangsRechnungViewModel);
        }

        public void AddEingangsRechnung()
        {
            ActivateItem(_addEingangsRechnungViewModel);
        }

        public void Handle(EventMessage message)
        {
            throw new NotImplementedException();
        }
    }

}
