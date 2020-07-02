using Caliburn.Micro;
using InvoiceInventory.Events;
using InvoiceInventory.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceInventory.ViewModels
{
    [Export(typeof(IBaseAddRechnungViewModel))]
    public class BaseAddRechnungViewModel : Screen, IBaseAddRechnungViewModel
    {
        #region Constructor
        [ImportingConstructor]
        public BaseAddRechnungViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
           
           // ClearFields();
        }
        #endregion

        #region Private Fields
        IEventAggregator _eventAggregator;
        //internal protected bool isDirty;
        #endregion




        #region Properties




        private int _RechnungsId;
        public int RechnungsId
        {
            get { return _RechnungsId; }
            set
            {
                if (value != _RechnungsId)
                {
                    _RechnungsId = value;
                    NotifyOfPropertyChange(() => RechnungsId);
                    //isDirty = true;
                }
            }
        }



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
                    //isDirty = true;
                    MessageIsDirty();
                }
            }
        }


        private string _RechnungsNummer;
        public string RechnungsNummer
        {
            get { return _RechnungsNummer; }
            set
            {
                if (value != _RechnungsNummer)
                {
                    _RechnungsNummer = value;
                    NotifyOfPropertyChange(() => RechnungsNummer);
                    //isDirty = true;
                    MessageIsDirty();

                }
            }
        }


        private bool _istStorniert;
        public bool IstStorniert
        {
            get { return _istStorniert; }
            set
            {
                if (value != _istStorniert)
                {
                    _istStorniert = value;
                    NotifyOfPropertyChange(() => IstStorniert);
                    //isDirty = true;
                    MessageIsDirty();
                }
            }
        }



        private bool _IstAusgebucht;

        public bool IstAusgebucht
        {
            get { return _IstAusgebucht; }
            set
            {
                if (value != _IstAusgebucht)
                {
                    _IstAusgebucht = value;
                    NotifyOfPropertyChange(() => IstAusgebucht);
                    //isDirty = true;
                    MessageIsDirty();
                }
            }
        }

        #endregion


        #region Methods
        public void SetFields(int ID, DateTime rDatum, string RNr, bool istStorno, bool istAusbuch)
        {
            RechnungsId = ID;
            Datum = rDatum;
            RechnungsNummer = RNr;
            IstStorniert = istStorno;
            IstAusgebucht = istAusbuch;

        }

        public void ClearFields()
        {
            RechnungsId = 0;
            Datum = DateTime.Now;
            RechnungsNummer = "";
            IstStorniert = false;
            IstAusgebucht = false;
            //isDirty = false;
        }

        private void MessageIsDirty()
        {
          
                _eventAggregator.PublishOnUIThread(new BaseAddRechnungVMPropertyChangedMessage(Enums.enumRechnungsArt.AusgangsRechnung)); 
            
        }

        #endregion
    }
}
