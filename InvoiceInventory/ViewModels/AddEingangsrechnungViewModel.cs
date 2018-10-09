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
    [Export(typeof(IAddEingangsrechnungViewModel))]
   public class AddEingangsrechnungViewModel:Screen,IAddEingangsrechnungViewModel
    {

        [ImportingConstructor]
        public AddEingangsrechnungViewModel(IBaseAddRechnungViewModel _BaseRechnungVM)
        {
            _BaseAddRechnungViewVM = _BaseRechnungVM;
            WasAuchImmer = "Quertz";
        }

        private IBaseAddRechnungViewModel _BaseAddRechnungViewVM;
        public IBaseAddRechnungViewModel BaseAddRechnungViewVM
        {
            get { return _BaseAddRechnungViewVM; }
            set
            {
                if (value != _BaseAddRechnungViewVM)
                {
                    _BaseAddRechnungViewVM = value;
                    NotifyOfPropertyChange(() => BaseAddRechnungViewVM);
                    //  isDirty = true;
                }
            }
        }



        private string _WasAuchImmer;
        public string WasAuchImmer
        {
            get { return _WasAuchImmer; }
            set
            {
                if (value != _WasAuchImmer)
                {
                    _WasAuchImmer = value;
                    NotifyOfPropertyChange(() => WasAuchImmer);
                    //  isDirty = true;
                }
            }
        }
    }
}
