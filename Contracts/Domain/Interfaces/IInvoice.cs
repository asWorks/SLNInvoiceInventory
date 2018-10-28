using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain.Interfaces
{
    public interface IInvoice
    {
        int RechnungsId { get; }
        DateTime Datum { get; set; }
        string RechnungsNummer { get; set; }
        bool IstStorniert { get; }
        bool IstAusgebucht { get; }

        bool Storno(IStornoReference stornoReference);

        bool Ausbuchen(IBuchungsReference buchungsTemplate);

    }
}
