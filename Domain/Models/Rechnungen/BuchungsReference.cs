using Contracts.Domain.BaseClasses;
using Contracts.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Rechnungen
{
    public class BuchungsReference : IBuchungsReference
    {
        public BuchungsReference(BaseRechnung invoice, DateTime datum, string bemerkung)

        {
            if (invoice == null)
            {
                throw new ArgumentNullException("Rechnung darf nicht leer sein");
            }
            if (datum == null)
            {
                throw new ArgumentNullException("Datum darf nicht leer sein");
            }



            Rechnung = invoice;
            Datum = datum;
            Bemerkung = bemerkung;

        }

        private BuchungsReference()
        {

        }

       
        public int BuchungsReferenceId { get; private set; }
        public string Bemerkung { get; private set; }
        public DateTime? Datum { get; private set; }


        public int RechnungsRefId { get;private set; }
        [ForeignKey("RechnungsRefId")]
        public BaseRechnung Rechnung { get;  set; }

        public int User { get; private set; }
    }
}
