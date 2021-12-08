using System;
using System.Net.Mail;
using OOPEksammenSW3.Users;
using OOPEksammenSW3.Global;

namespace OOPEksammenSW3.Users
{
    public class User : IComparable<User>
    {
        public event EventHandler BelowBalanceThreshold;

        private static DanskKrone _balanceThreshold = new DanskKrone(50);

        public Id<User> Id { get => _id; }

        public Username Username { get => _userName; }

        public DanskKrone Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                if (_balance < _balanceThreshold)
                    OnBelowBalanceThreshold(EventArgs.Empty);
            }
        }

        private Id<User> _id;

        private Name _firstName;

        private Name _lastName;

        private MailAddress _email = new MailAddress("nil@nil");

        private Username _userName;

        private DanskKrone _balance = new DanskKrone(0);

        public override string ToString()
        {
            return $"{_firstName.String} {_lastName.String} ({_email.Address}) BALANCE : {_balance}";
        }

        public override bool Equals(object obj)
        {
            User other = obj as User;
            if (other == null)
                return false;

            if (GetHashCode() == other.GetHashCode())
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return _id.Number;
        }

        public int CompareTo(User other)
        {
            return Id.Number.CompareTo(other.Id.Number);
        }

        protected virtual void OnBelowBalanceThreshold(EventArgs e)
        {
            EventHandler handler = BelowBalanceThreshold;
            handler?.Invoke(this, e);
        }

        public User(int id, Name firstName, Name lastName, Username username, DanskKrone balance, MailAddress email)
        {
            _id = new Id<User>(id);
            _userName = username;
            _firstName = firstName;
            _lastName = lastName;
            _balance = balance;
            _email = email;
        }
    }
}