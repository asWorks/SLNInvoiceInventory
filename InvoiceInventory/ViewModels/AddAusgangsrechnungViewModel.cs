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
    [Export(typeof(IAddAusgangsrechnungViewModel))]
   public class AddAusgangsrechnungViewModel:Screen,IAddAusgangsrechnungViewModel
    {

        [ImportingConstructor]
        public AddAusgangsrechnungViewModel(IBaseAddRechnungViewModel _BaseRechnungVM)
        {
            _BaseAddRechnungViewVM = _BaseRechnungVM;
            Zuzahlung = 11;
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


        private Decimal _Zuzahlung;
        public Decimal Zuzahlung
        {
            get { return _Zuzahlung; }
            set
            {
                if (value != _Zuzahlung)
                {
                    _Zuzahlung = value;
                    NotifyOfPropertyChange(() => Zuzahlung);
                    //  isDirty = true;
                }
            }
        }
    }
}
