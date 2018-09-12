using Contracts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rechnungen
{
   public class BuchungsResult_Failure:IBuchungsResult
    {
        public BuchungsResult_Failure(IInvoice invoice, string buchugsresult)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException("Rechnung", "Rechnung darf nicht Null sein");
            }
            Invoice = invoice;
            Buchungsresult = buchugsresult;
        }

        public string Buchungsresult { get; set; }
        public IInvoice Invoice { get; }

        public bool excute()
        {
            Console.WriteLine(string.Format("Rechnung {0} wurde mit Fehlern verarbeitet.", Invoice.RechnungsNummer));
            Console.WriteLine("Buchung wird rückgängig gemacht");
            return true;
        }
    }
}
