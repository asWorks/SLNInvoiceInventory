using Contracts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rechnungen
{
    public class BuchungsResult_IO:IBuchungsResult
    {

        public BuchungsResult_IO(IInvoice invoice,string buchugsresult)
        {
            if (invoice==null)
            {
                throw new ArgumentNullException("Rechnung", "Rechnung darf nicht Null sein");
            }
            Invoice = invoice;
            Buchungsresult = buchugsresult;
        }

        public string Buchungsresult { get; }
        public IInvoice Invoice { get; }

        public bool excute()
        {
            Console.WriteLine(string.Format("Rechnung {0} wurde Fehlerfrei verarbeitet.", Invoice.RechnungsNummer));
            return true;
        }
    }
}
