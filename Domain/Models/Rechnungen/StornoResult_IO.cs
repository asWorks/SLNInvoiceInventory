using Contracts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rechnungen
{
    public class StornoResult_IO:IStornoResult
    {

        public StornoResult_IO(IInvoice invoice, string stornoresult)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException("Rechnung", "Rechnung darf nicht Null sein");
            }
            Invoice = invoice;
            StornoResult = stornoresult;
        }

        public string StornoResult { get; }
        public IInvoice Invoice { get; }

        public bool excute()
        {
            Console.WriteLine(string.Format("Rechnung {0} wurde Fehlerfrei storniert.", Invoice.RechnungsNummer));
            return true;
        }

    }
}
