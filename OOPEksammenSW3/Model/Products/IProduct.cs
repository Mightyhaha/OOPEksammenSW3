using OOPEksammenSW3.Model.Global;

namespace OOPEksammenSW3.Model.Products
{    public interface IProduct
    {
        bool IsActive { get; set; }
        bool CanBeBoughtOnCredit { get; set; }
        DanskKrone Price { get; }
        int Id { get; }

        string ToString();
    }
}