using OOPEksammenSW3.Global;


namespace OOPEksammenSW3.Products
{
   public class Product
    {
        public virtual bool IsActive { get; set; }

        public bool CanBeBoughtOnCredit { get; set;}

        public DanskKrone Price { get => _price; }

        public Id<Product> Id { get => _id; }

        private Id<Product> _id;

        private Name _name;

        private DanskKrone _price = new DanskKrone(0);

        public override string ToString()
        {
            return _id.Number + " " + _name.String + " " + _price.ToString();
        }

        public Product(int id, Name name, DanskKrone price, bool isActive, bool canBeBoughtOnCredit)
        {
            _id = new Id<Product>(id);
            _name = name;
            _price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
    }
}
