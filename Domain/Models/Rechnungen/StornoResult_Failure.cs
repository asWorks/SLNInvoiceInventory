using Contracts.Domain.Interfaces;
using System;

namespace Domain.Models.Rechnungen
{
    public class StornoResult_Failure : IStornoResult
    {

        public StornoResult_Failure(IInvoice invoice, string stornoresult)
        {

            if (invoice == null)
            {
                throw new ArgumentNullException("Rechnung", "Rechnung darf nicht Null sein");
            }
            Invoice = invoice;
            StornoResult = stornoresult;
        }

        public string StornoResult { get; set; }
        public IInvoice Invoice { get; }

        public bool excute()
        {
            Console.WriteLine(string.Format("Rechnung {0} konnte nicht stornert werden.", Invoice.RechnungsNummer));
            Console.WriteLine("Buchung wird rückgängig gemacht");
            return true;
        }
    }
}
