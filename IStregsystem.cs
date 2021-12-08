using System;
using System.Collections.Generic;
using OOPEksammenSW3.Transaction;
using OOPEksammenSW3.Global;
using OOPEksammenSW3.Product;
using OOPEksammenSW3.User;

namespace OOPEksammenSW3
{
    internal interface IStregsystem
    {
        IEnumerable<Product> ActiveProducts { get; }

        event EventHandler<User> UserBalanceBelowThreshold;

        InsertCashTransaction AddCreditToAccount(User user, DanskKrone amount);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductById(int idNumber);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        User GetUserByUsername(Username username);
        IEnumerable<User> GetUsers(Predicate<User> predicate);
    }
}