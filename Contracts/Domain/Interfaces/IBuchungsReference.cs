using Contracts.Domain.BaseClasses;
using System;

namespace Contracts.Domain.Interfaces
{
    public interface IBuchungsReference
    {
        int BuchungsReferenceId { get; }
        string Bemerkung { get;}
        DateTime? Datum { get;}
        int RechnungsRefId { get; }
        BaseRechnung Rechnung { get; set; }

        int User { get; }

    }
}