using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Rechnungen
{
    public class AusgangsRechnung_Grid:AusgangsRechnung
    {
        public AusgangsRechnung_Grid(DateTime datum, string rechnungsnummer):base(datum,rechnungsnummer)
        {

        }

        public AusgangsRechnung_Grid():base()
        {

        }


       
   

        public string SetRechnungsNummer
        {
            get { return this._RechnungsNummer; }
            set
            {
                if (value != this._RechnungsNummer)
                {
                    this._RechnungsNummer = value;
                   
                }
            }
        }


    }
}
