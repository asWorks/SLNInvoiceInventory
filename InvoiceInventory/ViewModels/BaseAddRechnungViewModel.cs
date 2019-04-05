using Caliburn.Micro;
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
    public class BaseAddRechnungViewModel:Screen,IBaseAddRechnungViewModel
    {
         
        public BaseAddRechnungViewModel()
        {
            RechnungsNummer = "zzzTemp";
        }


        private int _RechnungsId;
        public int  RechnungsId
        {
            get { return _RechnungsId; }
            set
            {
                if (value != _RechnungsId)
                {
                    _RechnungsId = value;
                    NotifyOfPropertyChange(() => RechnungsId);
                    //  isDirty = true;
                }
            }
        }



        private DateTime? _Datum;
        public DateTime? Datum
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
                    //  isDirty = true;
                }
            }
        }


        private bool _istStorniert;
        public bool istStorniert
        {
            get { return _istStorniert; }
            set
            {
                if (value != _istStorniert)
                {
                    _istStorniert = value;
                    NotifyOfPropertyChange(() => istStorniert);
                    //  isDirty = true;
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
                    //  isDirty = true;
                }
            }
        }

       

        public void SetFields(int ID,DateTime rDatum,string RNr, bool istStorno,bool istAusbuch)
        {
            RechnungsId = ID;
            Datum = rDatum;
            RechnungsNummer = RNr;
            istStorniert = istStorno;
            IstAusgebucht = istAusbuch;

        }

        public void ClearFields()
        {
            RechnungsId = 0;
            Datum = DateTime.Now;
            RechnungsNummer = "-";
            istStorniert = false;
            IstAusgebucht = false;
        }
    }
}
