using System.Collections.Generic;
using System.Linq;
using OOPEksammenSW3.Model;
using OOPEksammenSW3.Model.Products;
using OOPEksammenSW3.Model.Transactions;
using OOPEksammenSW3.Model.Users;
using OOPEksammenSW3.View;

namespace OOPEksammenSW3.Controller.Commands
{
    public class BuyCommand : ICommand
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private Username _username;
        private IList<int> _productIdList;

        public BuyCommand(IStregsystem stregsystem, IStregsystemUI ui, Username username, IList<int> productIdList)
        {
            _stregsystem = stregsystem;
            _ui = ui;
            _username = username;
            _productIdList = productIdList;
        }

        public void Execute()
        {
            IUser user = _stregsystem.GetUserByUsername(_username);

            IEnumerable<IProduct> products = _productIdList.Select(id => 
                _stregsystem.GetProductById(id));

            foreach (Product product in products)
            {
                BuyTransaction transaction = _stregsystem.BuyProduct(user, product);
                _ui.DisplayUserBuysProduct(transaction); 
            }
            
        }
    }
}