using Caliburn.Micro;
using InvoiceInventory.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceInventory.ViewModels
{
    [Export(typeof(IBaseAddRechnungViewModel))]
    public class BaseAddRechnungViewModel:Screen,IBaseAddRechnungViewModel
    {
         
        public BaseAddRechnungViewModel()
        {
            RechnungsNummer = "zzzTemp";
        }

        public int RechnungsId { get; set; }
        public DateTime? Datum { get; set; }
        public string RechnungsNummer { get; set; }
        public bool istStorniert { get; set; }
        public bool IstAusgebucht { get; set; }
    }
}
