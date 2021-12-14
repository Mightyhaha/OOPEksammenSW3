using OOPEksammenSW3.Global;

namespace OOPEksammenSW3.Products
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