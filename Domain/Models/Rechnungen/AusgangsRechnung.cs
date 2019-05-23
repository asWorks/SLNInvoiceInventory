using Contracts.Domain.BaseClasses;
using System;

namespace Domain.Models.Rechnungen
{
    public class AusgangsRechnung : BaseRechnung
    {

        public AusgangsRechnung(DateTime datum, string rechnungsnummer) : base(rechnungsnummer, datum)
        {

        }

        public AusgangsRechnung() : base()
        {

        }

        public decimal? Umsatzsteuer { get; set; }
        ////public decimal Netto { get; set; }


        private decimal _Netto;
        public decimal Netto
        {
            get { return _Netto; }
            set
            {                if (value != _Netto)
                {
                    _Netto = value;

                    if ((Brutto==0 || Brutto == null) && Zuzahlung!=0)
                    {
                        _Brutto = Netto + Zuzahlung;
                    }
                    if (Zuzahlung==0 && Brutto!=0)
                    {
                        Zuzahlung = Brutto - Netto ?? 0;
                    }
                }
            }
        }

        private decimal _Zuzahlung;
        public decimal Zuzahlung
        {
            get { return _Zuzahlung; }
            set
            {
                if (value != _Zuzahlung)
                {
                    _Zuzahlung = value;
                    CalulateFields(value, Netto, Zuzahlung, (v,n,z) =>
                       {
                           ////if ()
                           ////{

                           ////}
                       });                   
                }
            }
        }
        ////public decimal Zuzahlung { get; set; }

        //public decimal Brutto { get; set; }


        private decimal? _Brutto;
        public decimal? Brutto
        {
            get { return _Brutto; }
            set
            {
                if (value != _Brutto)
                {
                    _Brutto = value;
                    if (Netto == 0 && Zuzahlung != 0)
                    {
                        _Netto = Brutto - Zuzahlung ?? 0; 
                    }

                    if (Zuzahlung == 0 && Netto != 0)
                    {
                        Zuzahlung=Brutto ?? 0-Netto;
                    }

                }
            }
        }


      void CalulateFields(decimal brutto, decimal netto, decimal zuzahlung, Action<decimal,decimal,decimal> DoExecute)
        {
             DoExecute(brutto, netto,zuzahlung);
        }


    }
}
