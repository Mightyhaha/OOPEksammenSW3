using System;
using System.Collections.Generic;
using OOPEksammenSW3.Transactions;
using OOPEksammenSW3.Global;
using OOPEksammenSW3.Products;
using OOPEksammenSW3.Users;
using OOPEksammenSW3.Exceptions;
using System.Linq;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace OOPEksammenSW3
{
    internal class Stregsystem : IStregsystem
    {
        public event EventHandler<User> UserBalanceBelowThreshold;

        public IEnumerable<Product> ActiveProducts { get => _products.FindAll(x => x.IsActive); }

        private List<Product> _products = new List<Product>();

        private List<Transaction> _transactions = new List<Transaction>();

        private List<User> _users = new List<User>();


        public Stregsystem(string productFileAddress, string userFileAddress)
        {
            foreach (string line in File.ReadLines(productFileAddress).Skip(1))
            {
                string[] subs = line.Split(';');

                string idString = subs[0];
                int id = Convert.ToInt32(idString);

                string nameString = subs[1];
                nameString = Regex.Replace(nameString, "<.*?>", String.Empty);
                nameString = nameString.Replace("\"", String.Empty);
                Name name = new Name(nameString);

                string priceString = subs[2];
                int priceInt = Convert.ToInt32(priceString);
                DanskKrone price = new DanskKrone(priceInt);

                string isActiveString = subs[3];
                int isActiveInt = Convert.ToInt32(isActiveString);
                bool isActive = Convert.ToBoolean(isActiveInt);

                Product product = new Product(id, name, price, isActive, false);
                _products.Add(product);
            }

            foreach (string line in File.ReadLines(userFileAddress).Skip(1))
            {
                string[] subs = line.Split(',');

                string idString = subs[0];
                int id = Convert.ToInt32(idString);

                string firstNameString = subs[1];
                Name firstName = new Name(firstNameString);

                string lastNameString = subs[2];
                Name lastName = new Name(lastNameString);

                string usernameString = subs[3];
                Username username = new Username(usernameString);

                string balanceString = subs[4];
                int balanceInt = Convert.ToInt32(balanceString);
                DanskKrone balance = new DanskKrone(balanceInt);

                string emailString = subs[5];
                MailAddress email = new MailAddress(emailString);

                User user = new User(id, firstName, lastName, username, balance, email);
                _users.Add(user);
                user.BelowBalanceThreshold += OnUserBalanceBelowThreshold;
            }
        }

        protected virtual void OnUserBalanceBelowThreshold(object user, EventArgs e)
        {
            EventHandler<User> handler = UserBalanceBelowThreshold;
            handler?.Invoke(this, (User)user);
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction transaction = new BuyTransaction(user, product);
            ExecuteTransaction(transaction);
            return transaction;
        }

        public InsertCashTransaction AddCreditToAccount(User user, DanskKrone amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(user, amount);
            ExecuteTransaction(transaction);
            return transaction;
        }

        public Product GetProductById(int idNumber)
        {
            List<Product> found = _products.FindAll(x => x.Id.Number == idNumber);
            if (0 < found.Count)
                return found[0];
            else
                throw new ProductDoesExist($"product with id {idNumber} does not exist");
        }

        public IEnumerable<User> GetUsers(Predicate<User> predicate)
        {
            return _users.FindAll(predicate);
        }

        public User GetUserByUsername(Username username)
        {
            List<User> found = _users.FindAll(x => username.ToString() == x.Username.ToString());
            if (0 < found.Count)
                return found[0];
            else
                throw new UserNotExist($"user with username {username.ToString()} does not exist");
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.FindAll(x => x.User == user).Take(count);
        }

        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
            log(transaction);
        }

        private void log(Transaction transaction)
        {
            using StreamWriter sw = File.AppendText("TransactionLog.txt");
            sw.WriteLine(transaction.ToString());
        }
    }
}