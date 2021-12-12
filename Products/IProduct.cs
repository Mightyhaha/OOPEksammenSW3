using OOPEksammenSW3.Global;

namespace Stregsystem.Products
{
    public interface IProduct
    {
        bool IsActive { get; set; }
        bool CanBeBoughtOnCredit { get; set; }
        DanskKrone Price { get; }
        IId<IProduct> Id { get; }

        string ToString();
    }
}