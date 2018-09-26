using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domain.Enums
{
    public enum  enumPartnerKennzeichen
    {
        Lieferant,
        Patient,
        Krankenkasse

    }

    public enum enumAdressKennzeichen
    {
        Postanschrift,
        Rechnungsadresse,
        Lieferadresse
    }

    public enum enumKontaktKenzeichen
    {
        Mobiltelefon,
        Festnetz,
        TelefonBeruf,
        Emailadresse,
        Webseite

    }
}
