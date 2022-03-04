using System;
using OOPEksammenSW3.Model.Global;
using OOPEksammenSW3.Model.Users;

namespace OOPEksammenSW3.Model.Transactions
{
    public abstract class Transaction
    {
        public IUser User { get => _user;}

        protected IUser _user;

        protected DanskKrone _amount = new DanskKrone(0);

        protected DateTime _date = new DateTime();

        private int _id;

        protected Transaction(IUser user, DanskKrone amount, IIdProvider idProvider)
        {
            _id = idProvider.GetNextId();
            _user = user;
            _amount = amount;
        }
        public virtual void Execute()
        {
            _date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{_id} {_user.ToString()} {_amount} {_date.ToString()}";
        }
    }
}