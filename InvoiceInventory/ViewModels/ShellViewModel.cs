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

        public ShellViewModel()
        {



        }

        [ImportingConstructor]
        public ShellViewModel(ITestViewModel testVM, IEventAggregator events)
        {
            _events = events;
            _testViewModel = testVM;
            events.Subscribe(this);

        }





        public void Test()
        {
            ActivateItem(_testViewModel);
        }



        public void Handle(EventMessage message)
        {
            throw new NotImplementedException();
        }
    }

}
