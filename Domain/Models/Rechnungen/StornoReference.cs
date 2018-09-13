using Contracts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rechnungen
{
    public class StornoReference:IStornoReference
    {
        public StornoReference(IInvoice invoice,DateTime stornoDatum,string stornogrund, int User)
        {
            if (invoice == null)
            {
                throw new ArgumentNullException("Rechung darf nicht null sein");

            }

            if (stornoDatum==null)
            {
                throw new ArgumentNullException("StornoDatum darf nicht null sein");
            }
            if (stornogrund.Length==0)
            {
                throw new ArgumentNullException("Stornogrund darf nicht leer sein");
            }

            StornoGrund = stornogrund;
            Datum = stornoDatum;
            Rechnung = invoice;
            

        }
        public int StornoReferenceId { get; set; }
        public string StornoGrund { get; set; }
        public DateTime Datum { get; set; }
      
        public int RechnungsId { get; set; }
        public IInvoice Rechnung { get; set; }
        public int User { get; set; }
        public bool result { get; set; }
    }
}
