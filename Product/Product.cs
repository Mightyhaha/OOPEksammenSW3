using OOPEksammenSW3.Currency

namespace OOPEksammenSW3.Product
{
    public class Product
    {
        public Id<Product> Id { get => _id; }
        public Ddk Price {get => _price; }

        private Id<Product> _id = new Id<Product>();

        private string _name = new Name();

        private DanskKrone _price = new Price();
        private int price;

        



        public void CanBeBoughtOnCredit()
        {

        }
    }
}
