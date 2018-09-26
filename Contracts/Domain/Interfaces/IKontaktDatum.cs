using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain.Enums;

namespace Contracts.Domain.Interfaces
{
   public interface IKontaktDatum
    {
        int KontaktDatumId { get; set; }
        enumKontaktKenzeichen KontaktKennzeichen { get; set; }
        string KontaktInfo { get; set; }

    }
}
