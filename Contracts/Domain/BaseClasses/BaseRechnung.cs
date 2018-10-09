using Contracts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain.BaseClasses
{
   public class BaseRechnung:IInvoice
    {

        public BaseRechnung(string rechnungsnummer,DateTime datum)
        {
            if (datum==null)
            {
                throw new ArgumentNullException("Datum darf nicht null sein");
            }
            if (rechnungsnummer.Length==0)
            {
                throw new ArgumentNullException("Rechnungsnummer darf nicht leer sein");
            }

            RechnungsNummer = rechnungsnummer;
            Datum = datum;
            IstStorniert = false;
            IstAusgebucht = false;
        }

        protected BaseRechnung()
        {

        }
        [Key]
        public int RechnungsId { get; private set; }
        public DateTime? Datum { get; private set; }
        public string RechnungsNummer { get; private set; }
        public bool IstStorniert { get; private set; }
        public bool IstAusgebucht { get; private set; }

        public virtual bool Storno(IStornoReference stornoReference)
        {
            IstStorniert = true;
            return true;
        }

        public bool Ausbuchen(IBuchungsReference buchungsTemplate)
        {
            if (buchungsTemplate!=null)
            {
                buchungsTemplate.Rechnung = this;
            }
            IstAusgebucht = true;
            return true;
        }
    }
}
