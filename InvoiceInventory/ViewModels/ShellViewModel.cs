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
        private ITestPeopleViewModel _TestPeopleViewModel;

        public ShellViewModel()
        {



        }

        [ImportingConstructor]
        public ShellViewModel(ITestViewModel testVM,
            IAddAusgangsrechnungViewModel AddAusgangsRechnungVM, 
            IAddEingangsrechnungViewModel AddEingangsRechnungVM,
            ITestPeopleViewModel TestPeopleVM, 
            IEventAggregator events)
        {
            _events = events;
            _testViewModel = testVM;
            _addAusgangsRechnungViewModel = AddAusgangsRechnungVM;
            _addEingangsRechnungViewModel = AddEingangsRechnungVM;
            _TestPeopleViewModel = TestPeopleVM;

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
            //DeactivateItem(_addAusgangsRechnungViewModel,false);
            ActivateItem(_addEingangsRechnungViewModel);
        }

        public void TestPeople()
        {
            ActivateItem(_TestPeopleViewModel);
        }

        public void Handle(EventMessage message)
        {
            throw new NotImplementedException();
        }
    }

}
