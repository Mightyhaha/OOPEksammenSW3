using System;
using OOPEksammenSW3.Model;
using OOPEksammenSW3.Model.Products;
using OOPEksammenSW3.Model.Transactions;
using OOPEksammenSW3.Model.Users;

namespace OOPEksammenSW3.View
{
    internal class StregsystemCLI : IStregsystemUI
    {
        public event EventHandler<string> CommandEntered;

        private bool _running = true;

        private IStregsystem _stregsystem;

        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine($"ERROR: {errorString}");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }

        public void DisplayUserInfo(IUser user)
        {
            Console.WriteLine(user.ToString());
        }

        private void DrawUI()
        {
            foreach (Product product in _stregsystem.ActiveProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.Write("#");
        }

        public void Start()
        {
            while (_running)
            {
                DrawUI();
                string command = Console.ReadLine();
                Console.WriteLine();
                OnCommandEntered(command);
                Console.WriteLine();
            }
        }

        public void Close()
        {
            _running = false;
        }

        protected virtual void OnCommandEntered(string command)
        {
            EventHandler<string> handler = CommandEntered;
            handler?.Invoke(this, command);
        }
    }
}