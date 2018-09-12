using System;

namespace Contracts.Domain.Interfaces
{
    public interface IStornoReference
    {

        int StornoReferenceId { get; set; }
        string StornoGrund { get; set; }
        DateTime Datum { get; set; }
        int RechnungsId { get; set; }
        IInvoice Rechnung { get; set; }

        int User { get; set; }


    }
}