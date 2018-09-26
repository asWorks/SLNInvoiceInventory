using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain.Enums;
using Contracts.Domain.Interfaces;

namespace Contracts.Domain.BaseClasses
{
   public class BaseAdresse:IAdresse
    {
        public int AdressId { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public enumAdressKennzeichen AdressKennzeichen { get; set; }
    }
}
