using System;
using System.Collections.Generic;
using System.Linq;
using OOPEksammenSW3.Model.Loggers;
using OOPEksammenSW3.Model.Products;
using OOPEksammenSW3.Model.Global;
using OOPEksammenSW3.Model.Transactions;
using OOPEksammenSW3.Model.Users;
using OOPEksammenSW3.Exceptions;

namespace OOPEksammenSW3.Model
{
    public class Stregsystem : IStregsystem
    {
        public event EventHandler<User> UserBalanceBelowThreshold;

        public IEnumerable<IProduct> ActiveProducts { get => _products.Where(x => x.IsActive); }

        protected IList<IProduct> _products;

        protected IList<Transaction> _transactions = new List<Transaction>();

        protected IList<IUser> _users;

        protected ILogger _logger;

        private IIdProvider _transactionIdProvider;

        public Stregsystem(IList<IProduct> products,
                           IList<IUser> users,
                           IIdProvider transactionIdProvider,
                           ILogger logger)
        {
            _products = products;
            _transactionIdProvider = transactionIdProvider;
            _logger = logger;

            _users = users;
            foreach (IUser user in _users)
                user.BelowBalanceThreshold += OnUserBalanceBelowThreshold;
        }

        protected virtual void OnUserBalanceBelowThreshold(object user, EventArgs e)
        {
            EventHandler<User> handler = UserBalanceBelowThreshold;
            handler?.Invoke(this, (User)user);
        }

        public BuyTransaction BuyProduct(IUser user, IProduct product)
        {
            BuyTransaction transaction =
                new BuyTransaction(user, product, _transactionIdProvider);
            ExecuteTransaction(transaction);
            return transaction;
        }

        public InsertCashTransaction AddCreditToAccount(IUser user, DanskKrone amount)
        {
            InsertCashTransaction transaction =
                new InsertCashTransaction(user, amount, _transactionIdProvider);
            ExecuteTransaction(transaction);
            return transaction;
        }

        public IProduct GetProductById(int id)
        {
            IProduct found = _products.Where(x => x.Id == id).FirstOrDefault();
            if (found != null)
                return found;
            else
                throw new ProductDoesExist($"product with id {id} does not exist");
        }

        public IEnumerable<IUser> GetUsers(Func<IUser, bool> predicate)
        {
            return _users.Where(predicate);
        }

        public IUser GetUserByUsername(Username username)
        {
            IUser found = _users.Where(x => username.ToString() == x.Username.ToString())
                                .FirstOrDefault();
            if (found != null)
                return found;
            else
                throw new ProductDoesExist($"user with username {username.ToString()} does not exist");
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.Where(x => x.User == user).Take(count);
        }

        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
            _logger.Log(transaction.ToString());
        }
    }
}