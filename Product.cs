namespace OOPEksammenSW3.Products
{
    public class Product
    {
        public Id<Product> Id { get => _id; }
        public Ddk Price {get => _price; }

        private Id<Product> _id = new Id<Product>();

        private string _name = new Name();

        private Ddk _price = new Price();
        private int price;

        



        public void CanBeBoughtOnCredit()
        {

        }
    }
}
