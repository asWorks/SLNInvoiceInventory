using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceInventory.Events
{
    public class LoadAusgangsRechnungMessage
    {
        public int RechnungsId;

        public LoadAusgangsRechnungMessage(int rechnungsId)
        {
            RechnungsId = rechnungsId;
        }
    }
}
