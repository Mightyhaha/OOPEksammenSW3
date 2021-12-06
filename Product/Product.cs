using OOPEksammenSW3.Global;


namespace OOPEksammenSW3.Product
{
    public class Product
    {
        public Id<Product> Id { get => _id; }
        public DanskKrone Price {get => _price; }
public bool IsActive { get => _IsActive; }

        public bool CanBeBoughtOnCredit { get => _canBeBoughtOnCredit; }

        private Id<Product> _id;

        private Name _name;

        private DanskKrone _price = new DanskKrone(0);

        private bool _IsActive = false;

        private bool _canBeBoughtOnCredit = false;

        public override string ToString()
        {
            return _id + " " + _name.String + " " + _price.ToString();
        }

        public Product(Id<Product> id, Name name, DanskKrone price, bool isActive, bool canBeBoughtOnCredit)
        {
            _id = new Id<Product>(id);
            _name = name;
            _price = price;
            _IsActive = isActive;
            _canBeBoughtOnCredit = canBeBoughtOnCredit;
        }
    }
}
