using Contracts.Domain.BaseClasses;
using Contracts.Domain.Interfaces;
using System;

namespace Domain.Models.Rechnungen
{
    public class AusgangsRechnung : BaseRechnung
    {
        public AusgangsRechnung(DateTime datum, string rechnungsnummer, int rechnungsId) : base(rechnungsnummer, datum,rechnungsId)
        {

        }

        public AusgangsRechnung(DateTime datum, string rechnungsnummer) : base(rechnungsnummer, datum)
        {

        }

        private AusgangsRechnung() : base()
        {

        }

        public decimal? Umsatzsteuer { get; set; }
        public decimal? Brutto { get; set; }

        public decimal? Netto { get; set; }

        public decimal?  Zuzahlung { get; set; }

        public override bool Storno(IStornoReference stornoReference)
        {
            // Do some housekeeping . . .
            base.Storno(stornoReference);
            return base.Storno(stornoReference);
        }


    }
}
