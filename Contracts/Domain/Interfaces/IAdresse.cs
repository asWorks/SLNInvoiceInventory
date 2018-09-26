using Contracts.Domain.Enums;

namespace Contracts.Domain.Interfaces
{
    public interface IAdresse
    {
        int AdressId { get; set; }
        enumAdressKennzeichen AdressKennzeichen { get; set; }
        string PLZ { get; set; }
        string Ort { get; set; }
        string Strasse { get; set; }
        string Hausnummer { get; set; }
    }
}
