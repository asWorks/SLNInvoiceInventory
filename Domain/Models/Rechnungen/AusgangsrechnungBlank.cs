using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rechnungen
{
  public class AusgangsrechnungBlank
    {

        public int RechnungsID { get; set; }
        public string RechnungsNummer { get; set; }
        public DateTime Datum { get; set; }

        public bool IstStorniert { get; set; }
        public bool IstAusgebucht { get; set; }

        public decimal? Brutto { get; set; }
        public decimal Netto { get; set; }

        public decimal Zuzahlung { get; set; }
    }
}
