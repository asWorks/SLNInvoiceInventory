using System;

namespace Contracts.Domain.Interfaces
{
    public interface IBuchungsReference
    {
        int BuchungsReferenceId { get; }
        string Bemerkung { get;}
        DateTime? Datum { get;}
        int RechnungsRefId { get; }
        //IInvoice Rechnung { get; }

        int User { get; }

    }
}