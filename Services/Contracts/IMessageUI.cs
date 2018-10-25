using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMessageUI
    {

        string Message { get; set; }
        string  Titel { get; set; }
        void MessageShow();
    }
}
