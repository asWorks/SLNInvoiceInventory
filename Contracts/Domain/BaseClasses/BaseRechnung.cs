using Contracts.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Domain.BaseClasses
{
    public abstract class BaseRechnung : IInvoice
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
           
        }

        protected BaseRechnung()
        {

        }
        [Key]
        public int RechnungsId { get; protected set; }
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

   
    }
}
