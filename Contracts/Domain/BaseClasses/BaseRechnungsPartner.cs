using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain.Enums;
using Contracts.Domain.Interfaces;

namespace Contracts.Domain.BaseClasses
{
   public class BaseRechnungsPartner:IRechnungsPartner
    {
        public int Id { get; set; }
     

        public IAdresse Adresse { get; set; }

        public IEnumerable<IKontaktDatum> Kontaktdaten { get; set; }
        enumPartnerKennzeichen IRechnungsPartner.PartnerKennzeichen { get; set; }
    }
}
