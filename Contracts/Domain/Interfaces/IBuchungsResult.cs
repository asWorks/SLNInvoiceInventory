using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain.Interfaces
{
    public interface IBuchungsResult
    {
       
        string Buchungsresult { get; }
        IInvoice Invoice { get; }
        bool excute();


    }
}
