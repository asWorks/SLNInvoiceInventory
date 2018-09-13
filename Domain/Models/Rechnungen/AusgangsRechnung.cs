using Contracts.Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rechnungen
{
   public class AusgangsRechnung:BaseRechnung
    {

        public AusgangsRechnung(DateTime datum, string rechnungsnummer):base(rechnungsnummer,datum)
        {

        }

       private AusgangsRechnung():base()
        {
                
        }

        public decimal? Umsatzsteuer { get; set; }
        public decimal Netto { get; set; }

        public decimal Zuzahlung { get; set; }
    }
}
