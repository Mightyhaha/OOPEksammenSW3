using System;
using OOPEksammenSW3.Model.Products;
using OOPEksammenSW3.Model.Global;
using OOPEksammenSW3.Model.Users;
using OOPEksammenSW3.Exceptions;

namespace OOPEksammenSW3.Model.Transactions
{
    public class BuyTransaction : Transaction
    {
        private IProduct _product;

        public BuyTransaction(IUser user, IProduct product, IIdProvider idProvider)
            : base(user, product.Price, idProvider)
        {
            _product = product;
        }

        public override void Execute()
        {
            if (TransactionIsLegal())
            {
                _user.Balance = _user.Balance - _amount;
                base.Execute();
            }
            else if (!_product.IsActive)
            {
                throw new ProductDoesExist($"{_product.ToString()} is not Active");
            }
            else if (!_product.CanBeBoughtOnCredit)
            {
                throw new InsufficientCredit
                    ($"{_user.ToString()} does not have enough credit to buy {_product.ToString()}");
            }
            else
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return $"Buy {_product.ToString()}: {base.ToString()}";
        }

        private bool TransactionIsLegal()
        {
            DanskKrone userProxyBalance = _user.Balance;
            userProxyBalance = userProxyBalance - _amount;
            return _product.IsActive
                   && (new DanskKrone(0) <= userProxyBalance || _product.CanBeBoughtOnCredit);
        }
    }
}