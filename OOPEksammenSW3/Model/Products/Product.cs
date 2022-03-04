using OOPEksammenSW3.Model.Global;


namespace OOPEksammenSW3.Model.Products
{
   public class Product : IProduct
    {
        public virtual bool IsActive { get; set; }

        public bool CanBeBoughtOnCredit { get; set; }

        public DanskKrone Price { get => _price; }

        public int Id { get => _id; }

        private int _id;

        private Name _name;

        private DanskKrone _price = new DanskKrone(0);

        public override string ToString()
        {
            return _id + " " + _name.String + " " + _price.ToString();
        }

        public Product(int id, IIdProvider idProvider, Name name, DanskKrone price, bool isActive, bool canBeBoughtOnCredit)
        {
            _id = idProvider.TryGetId(id);
            _name = name;
            _price = price;
            IsActive = isActive;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }
    }
}
