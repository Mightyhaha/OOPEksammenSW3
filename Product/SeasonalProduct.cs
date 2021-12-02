using System;
using OOPEksammenSW3.Product;
using OOPEksammenSW3.Global;

namespace OOPEksammenSW3.Product
{
     internal class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate
        {
            get => _seasonStartDate;
            private set
            {
                if (value < _seasonEndDate)
                {
                    _seasonStartDate = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public DateTime SeasonEndDate
        {
            get => SeasonEndDate;
            private set
            {
                if (_seasonStartDate < value)
                {
                    _seasonEndDate = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        private DateTime _seasonStartDate = new DateTime();
        private DateTime _seasonEndDate = new DateTime();

        public SeasonalProduct(Id<Product> id, Name name, DanskKrone price, bool active, bool canBeBoughtOnCredit,
        DateTime seasonStartDate, DateTime seasonEndDate)
        : base(id, name, price, active, canBeBoughtOnCredit)
        {
            _seasonStartDate = seasonStartDate;
            _seasonEndDate = seasonEndDate;
        }
    }
}