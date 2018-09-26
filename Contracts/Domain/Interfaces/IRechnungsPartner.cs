using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Domain.Enums;

namespace Contracts.Domain.Interfaces
{
    public interface IRechnungsPartner
    {
        int Id { get; set; }
        enumPartnerKennzeichen PartnerKennzeichen { get; set; }
    }
}
