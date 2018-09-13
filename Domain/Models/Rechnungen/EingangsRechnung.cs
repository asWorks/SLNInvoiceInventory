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

        //[Key]
        //public int RechnungsId { get; private set; }
        //public DateTime Datum { get; private set; }
        //public string RechnungsNummer { get; private set; }
        //public bool istStorniert { get; private set; }
        //public bool IstAusgebucht { get; private set; }

        //public IStornoResult Storno(IStornoReference stornoReference)
        //{
        //    throw new NotImplementedException();
        //}

        //public IBuchungsResult Ausbuchen(IBuchungsReference buchungsTemplate)
        //{
        //    IBuchungsResult res;
        //    if (IstAusgebucht==false)
        //    {
        //        res = new BuchungsResult_IO(this, "OK");
        //        IstAusgebucht = true;
        //        res.excute();
        //         return res;
        //    }
        //    else
        //    {
        //        res = new BuchungsResult_Failure(this, "Rechnung ist bereits ausgebucht.");
        //        res.excute();
        //        return res;
        //    }

           
        //}

    }
}
