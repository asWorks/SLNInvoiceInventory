using Contracts.Domain.BaseClasses;
using Contracts.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Rechnungen
{
    public class EingangsRechnung : BaseRechnung
    {
        public EingangsRechnung(DateTime datum, string rechnungsNummer) : base(rechnungsNummer, datum)
        {
             //Datum = datum;
            //RechnungsNummer = rechnungsNummer;
            //istStorniert = false;
            //IstAusgebucht = false;
        }

        private EingangsRechnung() : base()
        {

        }


        public bool IstStorniert { get; private set; }
        public bool IstAusgebucht { get; private set; }

        public virtual bool Storno(IStornoReference stornoReference)
        {
            IstStorniert = true;
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
