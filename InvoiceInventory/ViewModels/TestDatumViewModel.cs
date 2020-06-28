using Caliburn.Micro;
using System.ComponentModel.Composition;
using InvoiceInventory.Events;
using System;
using Syncfusion.Windows.Shared;

namespace InvoiceInventory.ViewModels
{
    [Export(typeof(ITestDatumViewModel))]
    public class TestDatumViewModel : Screen, ITestDatumViewModel, IHandle<EventMessage>
    {
        #region "Private Fields"
        private readonly IEventAggregator _events;
       

        #endregion


        #region "Constructors"
        [ImportingConstructor]
        public TestDatumViewModel(IEventAggregator events)
        {
            _events = events;
            events.Subscribe(this);
            Datum = new DateTime(2017, 10, 23);
            

        }


        #endregion



        #region "Properties"


        private DateTime _Datum;
        public DateTime Datum
        {
            get { return _Datum; }
            set
            {
                if (value != _Datum)
                {
                    _Datum = value;
                    NotifyOfPropertyChange(() => Datum);
                    //  isDirty = true;
                }
            }
        }


        #endregion

        #region "Methods"
        //##################

        #endregion

        #region "CallsFromView"
        //##################

        #endregion

        #region "Eventhandlers"
        //##################



        public void Handle(EventMessage message)
        {
            throw new System.NotImplementedException();
        }

        #endregion

    }

}

public interface ITestDatumViewModel
{
}