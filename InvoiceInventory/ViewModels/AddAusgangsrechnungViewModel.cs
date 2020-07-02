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
using System.Data.Entity;

namespace InvoiceInventory.ViewModels
{
    [Export(typeof(IAddAusgangsrechnungViewModel))]
    public class AddAusgangsrechnungViewModel : BaseAddRechnungViewModel, IAddAusgangsrechnungViewModel, IHandle<Events.BaseAddRechnungVMPropertyChangedMessage>
    {
        public enum RechnungState
        {
            RechnungNeu,
            RechnungBearbeitet
        };

        #region Constructors
        [ImportingConstructor]
        public AddAusgangsrechnungViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
            // _BaseAddRechnungViewVM = _BaseRechnungVM;
            Items = new ObservableCollection<string>();

        }
        #endregion



        #region Fields
        private IEventAggregator _eventAggregator;
        private bool runClearData;
        private RechnungState rechnungState;

        #endregion

        #region Properties

        //private IBaseAddRechnungViewModel _BaseAddRechnungViewVM;
        //public IBaseAddRechnungViewModel BaseAddRechnungViewVM
        //{
        //    get { return _BaseAddRechnungViewVM; }
        //    set
        //    {
        //        if (value != _BaseAddRechnungViewVM)
        //        {
        //            _BaseAddRechnungViewVM = value;
        //            NotifyOfPropertyChange(() => BaseAddRechnungViewVM);
        //            //  isDirty = true;
        //        }
        //    }
        //}



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
           

            AusgangsRechnung agRechnung;

            if (rechnungState == RechnungState.RechnungNeu)
            {

                agRechnung = CreateNeueRechnung();
            }
            else
            {
                agRechnung = CreateBearbeiteteRechnung();

            }


            if (IstStorniert)
            {
                agRechnung.Storno(new StornoReference(agRechnung,DateTime.Now, "Irgendwas", 5));
            }

           // agRechnung.IstStorniert = IstStorniert;
            agRechnung.IstAusgebucht = IstAusgebucht;
            agRechnung.Zuzahlung = Zuzahlung;
            agRechnung.Brutto = Brutto;
            agRechnung.Netto = Netto;
            agRechnung.Umsatzsteuer = Umsatzsteuer;

            using (var db = new InvoiceModel())
            {
                if (rechnungState == RechnungState.RechnungBearbeitet)
                {

                    db.AusgangsRechnungen.Attach(agRechnung);
                    db.Entry(agRechnung).State = EntityState.Modified;
                }
                else
                {
                    db.AusgangsRechnungen.Add(agRechnung);
                }
                db.SaveChanges();
            }
           
            isDirty = false;
            _eventAggregator.PublishOnUIThread(new UpdateAusgangsRechnungenMessage());



        }

        private AusgangsRechnung CreateBearbeiteteRechnung()
        {
            return new AusgangsRechnung(Datum, RechnungsNummer, RechnungsId);
        }

        private AusgangsRechnung CreateNeueRechnung()
        {
            var RefRechnung = new AusgangsRechnung(Datum, RechnungsNummer);




            var agRechnung = new AusgangsRechnung(Datum, RechnungsNummer);
            if (IstStorniert)
            {
                agRechnung.Storno(new StornoReference(RefRechnung, DateTime.Now, "Mußte Sein", 23));
            }
            if (IstAusgebucht)
            {
                agRechnung.Ausbuchen(new BuchungsReference(RefRechnung, DateTime.Now, "Mußte Sein"));
            }



            return agRechnung;
        }


        public void LoadRechnung(int rID)
        {

            rechnungState = RechnungState.RechnungBearbeitet;

            using (var db = new InvoiceModel())
            {
                var rechnung = db.AusgangsRechnungen.Where(id => id.RechnungsId == rID).FirstOrDefault();
                if (rechnung != null)
                {
                  

                    RechnungsId = rechnung.RechnungsId;
                    RechnungsNummer = rechnung.RechnungsNummer;
                    Datum = rechnung.Datum;
                    IstStorniert = rechnung.IstStorniert;
                    IstAusgebucht = rechnung.IstAusgebucht;
                    Brutto = rechnung.Brutto;
                    Netto = rechnung.Netto;
                    Umsatzsteuer = rechnung.Umsatzsteuer;
                    Zuzahlung = rechnung.Zuzahlung;


                    isDirty = false;

                }

            }

        }

        public void AddNewRechnung()
        {
            rechnungState = RechnungState.RechnungNeu;
            Datum = DateTime.Now;
            IstStorniert = false;
            IstAusgebucht = false;
            Brutto = 0; Netto = 0;
            Umsatzsteuer = 0;
            Zuzahlung = 0;


            ClearFields();
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
            // var x = (BaseAddRechnungViewVM as BaseAddRechnungViewModel);
            // NotifyOfPropertyChange(() => BaseAddRechnungViewVM);
            Zuzahlung = 0;
            Brutto = 0;
            Netto = 0;
            Umsatzsteuer = 0;
            // x.ClearFields();
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
            if (message.RechnungsArt == Enums.enumRechnungsArt.AusgangsRechnung)
            {
                isDirty = true;
            }

        }
    }
}

