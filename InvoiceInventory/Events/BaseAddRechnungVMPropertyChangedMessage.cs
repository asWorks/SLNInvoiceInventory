using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvoiceInventory.Enums;

namespace InvoiceInventory.Events
{
    public partial class BaseAddRechnungVMPropertyChangedMessage
    {

        public enumRechnungsArt RechnungsArt;
        public BaseAddRechnungVMPropertyChangedMessage(enumRechnungsArt rechnungsArt)
        {
           RechnungsArt = rechnungsArt;
        }
    }
}
