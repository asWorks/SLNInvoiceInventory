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
using System.Windows.Documents;
using System.Windows;
using InvoiceInventory.Events;
using System.Collections.ObjectModel;

namespace InvoiceInventory.ViewModels
{
    [Export(typeof(IAddAusgangsrechnungViewModel))]
    public class AddAusgangsrechnungViewModel : Screen, IAddAusgangsrechnungViewModel, IHandle<Events.BaseAddRechnungVMPropertyChangedMessage>
    {

        #region Constructors
        [ImportingConstructor]
        public AddAusgangsrechnungViewModel(IEventAggregator eventAggregator, IBaseAddRechnungViewModel _BaseRechnungVM)
        {
            _eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
            _BaseAddRechnungViewVM = _BaseRechnungVM;
            Items = new ObservableCollection<string>();

        }
        #endregion



        #region Fields
        private IEventAggregator _eventAggregator;
        private bool runClearData;
        #endregion

        #region Properties

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



        private ObservableCollection<string> _Items;
        public ObservableCollection<string> Items
        {
            get { return _Items; }
            set
            {
                if (value != _Items)
                {
                    _Items = value;
                    NotifyOfPropertyChange(() => Items);
                    //  isDirty = true;
                }
            }
        }

        private bool _isDirty;
        public bool isDirty
        {
            get { return _isDirty; }
            private set
            {

                Items.Add(DateTime.Now.ToLongTimeString());
                if (value != _isDirty)
                {
                    _isDirty = value;
                    NotifyOfPropertyChange(() => isDirty);

                }
            }
        }

        private decimal? _Zuzahlung;


        public decimal? Zuzahlung
        {
            get { return _Zuzahlung; }
            set
            {
                if (value != _Zuzahlung)
                {
                    _Zuzahlung = value;
                    NotifyOfPropertyChange(() => Zuzahlung);
                    isDirty = true;
                }
            }
        }



        private decimal? _Brutto;
        public decimal? Brutto
        {
            get { return _Brutto; }
            set
            {
                if (value != _Brutto)
                {
                    _Brutto = value;
                    NotifyOfPropertyChange(() => Brutto);
                    isDirty = true;
                    checkValues();
                }
            }
        }


        private decimal? _Netto;
        public decimal? Netto
        {
            get { return _Netto; }
            set
            {
                if (value != _Netto)
                {
                    _Netto = value;
                    NotifyOfPropertyChange(() => Netto);
                    isDirty = true;
                    checkValues();
                }
            }
        }



        private decimal? _Umsatzsteuer;
        public decimal? Umsatzsteuer
        {
            get { return _Umsatzsteuer; }
            set
            {
                if (value != _Umsatzsteuer)
                {
                    _Umsatzsteuer = value;
                    NotifyOfPropertyChange(() => Umsatzsteuer);
                    isDirty = true;
                    checkValues();
                }
            }
        }


        #endregion

        #region Methods

        public void SaveData()
        {
            var x = (BaseAddRechnungViewVM as BaseAddRechnungViewModel);
            //if (x.Datum.HasValue)
            //{

            var RefRechnung = new AusgangsRechnung(x.Datum, x.RechnungsNummer);
            var ar = new AusgangsRechnung(x.Datum, x.RechnungsNummer);
            if (x.istStorniert)
            {
                ar.Storno(new StornoReference(RefRechnung, DateTime.Now, "Mußte Sein", 23));
            }
            if (x.IstAusgebucht)
            {
                ar.Ausbuchen(new BuchungsReference(RefRechnung, DateTime.Now, "Mußte Sein"));
            }


            ar.Zuzahlung = Zuzahlung;
            ar.Brutto = Brutto;
            ar.Netto = Netto;
            ar.Umsatzsteuer = Umsatzsteuer;

            using (var db = new InvoiceModel())
            {
                db.AusgangsRechnungen.Add(ar);
                db.SaveChanges();
            }
            x.isDirty = false;
            isDirty = false;

            //}

        }

        void checkValues()
        {
            if (!runClearData)
            {

                if (Brutto != 0 && Netto != 0 && Umsatzsteuer == 0)
                {
                    Umsatzsteuer = Brutto - Netto;
                }

                if (Brutto != 0 && Umsatzsteuer != 0 && Netto == 0)
                {
                    Netto = Brutto - Umsatzsteuer;
                }

                if (Netto != 0 && Umsatzsteuer != 0 && Brutto == 0)
                {
                    Brutto = Netto + Umsatzsteuer;
                }
            }
        }

        public void ClearFields()
        {
            runClearData = true;
            var x = (BaseAddRechnungViewVM as BaseAddRechnungViewModel);
            NotifyOfPropertyChange(() => BaseAddRechnungViewVM);
            Zuzahlung = 0;
            Brutto = 0;
            Netto = 0;
            Umsatzsteuer = 0;
            x.ClearFields();
            isDirty = false;

            runClearData = false;




        }
        #endregion


        public override void CanClose(Action<bool> callback)
        {
            // base.CanClose(callback);

            if (isDirty)
            {
                MessageBoxResult res = MessageBox.Show("Änderungen speichern ?", "", MessageBoxButton.YesNoCancel);

                switch (res)
                {
                    case MessageBoxResult.Cancel:
                        {

                            callback(false);
                            break;
                        }

                    case MessageBoxResult.No:
                        {
                            ClearFields();
                            callback(true);

                            break;
                        }

                    case MessageBoxResult.Yes:
                        {
                            SaveData();
                            ClearFields();
                            callback(true);
                            break;
                        }

                    default:
                        break;
                }


            }
            else
            {
                callback(true);
            }
        }

        public void Handle(BaseAddRechnungVMPropertyChangedMessage message)
        {
            isDirty = true;
        }
    }
}

