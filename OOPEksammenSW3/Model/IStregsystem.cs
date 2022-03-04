using System;
using System.Collections.Generic;
using OOPEksammenSW3.Model.Transactions;
using OOPEksammenSW3.Model.Global;
using OOPEksammenSW3.Model.Products;
using OOPEksammenSW3.Model.Users;

namespace OOPEksammenSW3.Model
{
    public interface IStregsystem
    {
        IEnumerable<IProduct> ActiveProducts { get; }

        event EventHandler<User> UserBalanceBelowThreshold;

        InsertCashTransaction AddCreditToAccount(IUser user, DanskKrone amount);
        BuyTransaction BuyProduct(IUser user, IProduct product);
        IProduct GetProductById(int idNumber);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        IUser GetUserByUsername(Username username);
        IEnumerable<IUser> GetUsers(Func<IUser, bool> predicate);
    }
}