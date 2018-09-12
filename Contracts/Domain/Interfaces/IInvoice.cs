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
        DateTime Datum { get;}
        string RechnungsNummer { get; }
        bool istStorniert { get; }
        bool IstAusgebucht { get; }

        IStornoResult Storno(IStornoReference stornoReference);

        IBuchungsResult Ausbuchen(IBuchungsReference buchungsTemplate);

    }
}
