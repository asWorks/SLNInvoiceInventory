using Caliburn.Micro;
using Contracts.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace Contracts.Domain.BaseClasses
{
    public class BaseRechnung :Screen, IInvoice
    {

        public BaseRechnung(string rechnungsnummer, DateTime datum)
        {
            if (datum == null)
            {
                throw new ArgumentNullException("Datum darf nicht null sein");
            }
            if (rechnungsnummer.Length == 0)
            {
                throw new ArgumentNullException("Rechnungsnummer darf nicht leer sein");
            }

            RechnungsNummer = rechnungsnummer;
            Datum = datum;
            IstStorniert = false;
            IstAusgebucht = false;
        }

        public BaseRechnung()
        {

        }

        [Key]
        public int RechnungsId { get; private set; }
        //public DateTime? Datum { get; private set; }

        private DateTime _Datum;
        public DateTime Datum
        {
            get { return _Datum; }
            set
            {
               
                    if (value != _Datum)
                    {

                        _Datum = value;

                    }
               

            }
        }


        private string _RechnungsNummer;
        public string RechnungsNummer
        {
            get { return _RechnungsNummer; }
            set
            {
                if (_RechnungsNummer == null)
                {
                    if (value != _RechnungsNummer)
                    {
                        _RechnungsNummer = value;
                    }

                }
            }
        }



        private bool _IstStorniert;
        public bool IstStorniert
        {
            get { return _IstStorniert; }
            set
            {
                if (value != _IstStorniert)
                {
                    _IstStorniert = value;
                    NotifyOfPropertyChange(() => IstStorniert);
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

       

        public virtual bool Storno(IStornoReference stornoReference)
        {
            IstStorniert = true;
            return true;
        }

        public bool Ausbuche(object context)
        {
            //if (buchungsTemplate != null)
            //{
            //    //buchungsTemplate.Rechnung = this;
            //}
            IstAusgebucht = true;
            return true;
        }

        public bool Ausbuchen(IBuchungsReference buchungsTemplate)
        {
            if (buchungsTemplate != null)
            {
                buchungsTemplate.Rechnung = this;
            }
            IstAusgebucht = true;
            return true;
        }

    }
}
