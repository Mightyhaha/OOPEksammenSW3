using OOPEksammenSW3.Global;
using OOPEksammenSW3.User;
using System;

namespace OOPEksammenSW3.Transaction
{
    internal class InsertCashTransaction : Transaction
    {
        public override void Execute()
        {
            _user.Balance += _amount;
            base.Execute();
        }

        public override string ToString()
        {
            return $"Insert: {base.ToString()}";
        }

        public InsertCashTransaction(User user, DanskKrone amount) : base(user, amount) { }
    }