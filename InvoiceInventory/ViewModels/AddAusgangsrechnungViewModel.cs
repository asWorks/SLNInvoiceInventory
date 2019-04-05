using Caliburn.Micro;
using InvoiceInventory.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalMySQL;
using Domain.Models.Rechnungen;


namespace InvoiceInventory.ViewModels
{
    [Export(typeof(IAddAusgangsrechnungViewModel))]
    public class AddAusgangsrechnungViewModel : Screen, IAddAusgangsrechnungViewModel
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

        public void SaveData()
        {
            var x = (BaseAddRechnungViewVM as BaseAddRechnungViewModel);
            if (x.Datum.HasValue)
            {

                var RefRechnung = new AusgangsRechnung(x.Datum.Value, x.RechnungsNummer);
                var ar = new AusgangsRechnung(x.Datum.Value, x.RechnungsNummer);
                if (x.istStorniert)
                {
                    ar.Storno(new StornoReference(RefRechnung, DateTime.Now, "Mußte Sein", 23));
                }
                if (x.IstAusgebucht)
                {
                    ar.Ausbuchen(new BuchungsReference(RefRechnung, DateTime.Now, "Mußte Sein"));
                }


                ar.Zuzahlung = Zuzahlung;

                using (var db = new InvoiceModel())
                {
                    db.AusgangsRechnungen.Add(ar);
                    db.SaveChanges();
                }


            }

        }

        public void ClearFields()
        {
            var x = (BaseAddRechnungViewVM as BaseAddRechnungViewModel);
            x.ClearFields();
            NotifyOfPropertyChange(() => BaseAddRechnungViewVM);
            Zuzahlung = 0;



        }
    }
}
