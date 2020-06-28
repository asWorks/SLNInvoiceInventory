using Caliburn.Micro;
using InvoiceInventory.Events;
using InvoiceInventory.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace InvoiceInventory.ViewModels
{

    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : Conductor<object>, IShellViewModel, IHandle<Events.LoadAusgangsRechnungMessage>
    {



        private readonly IEventAggregator _eventAggregator;
        private ITestViewModel _testViewModel;
        private IAddAusgangsrechnungViewModel _addAusgangsRechnungViewModel;
        private IAddEingangsrechnungViewModel _addEingangsRechnungViewModel;
        private ITestPeopleViewModel _TestPeopleViewModel;
        private ITestDatumViewModel _testDatumViewModel;

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
            _eventAggregator = events;
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
            AddAusgangsrechnungViewModel vm = (AddAusgangsrechnungViewModel)_addAusgangsRechnungViewModel;
            vm.LoadRechnung(0);
            ActivateItem(_addAusgangsRechnungViewModel);
        }

        public void AddEingangsRechnung()
        {
            //AddAusgangsrechnungViewModel vm = (AddAusgangsrechnungViewModel)_addAusgangsRechnungViewModel;
            //vm.LoadRechnung(0);
            ActivateItem(_addEingangsRechnungViewModel);
        }

        public void TestPeople()
        {
            ActivateItem(_TestPeopleViewModel);
        }

        public void TestDatum()
        {
            _testDatumViewModel = new TestDatumViewModel(_eventAggregator);
            ActivateItem(_testDatumViewModel);
        }

      
        public void Handle(LoadAusgangsRechnungMessage message)
        {
            AddAusgangsrechnungViewModel vm = (AddAusgangsrechnungViewModel)_addAusgangsRechnungViewModel;
            vm.LoadRechnung(message.RechnungsId);

            ActivateItem(_addAusgangsRechnungViewModel);
        }
    }

}
