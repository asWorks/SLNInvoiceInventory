using Contracts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceInventory.Interfaces
{
    public interface IInvoiceViewModel
    {
        int RechnungsId { get; set; }
        DateTime? Datum { get; set; }
        string RechnungsNummer { get; set; }
        bool istStorniert { get; set; }
        bool IstAusgebucht { get; set; }

        bool Storno(IStornoReference stornoReference);

        bool Ausbuchen(IBuchungsReference buchungsTemplate);
    }
}
