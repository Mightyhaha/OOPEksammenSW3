using OOPEksammenSW3.Model.Global;
using OOPEksammenSW3.Model.Users;
using System;

namespace OOPEksammenSW3.Model.Transactions
{
    public class InsertCashTransaction : Transaction
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

        public InsertCashTransaction(IUser user, DanskKrone amount, IIdProvider idProvider)
            : base(user, amount, idProvider) { }
    }
}