using System;
using OOPEksammenSW3.Currency;
using OOPEksammenSW3.Users;

namespace OOPEksammenSW3.Transcation
{
    internal abstract class Transaction
    {
        public User User { get => _user;}

        protected User _user;

        protected DanskKrone _amount = new DanskKrone(0);

        protected DateTime _date = new DateTime();

        private Id<Transaction> _id = new Id<Transaction>();

        protected Transaction(User user, DanskKrone amount)
        {
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