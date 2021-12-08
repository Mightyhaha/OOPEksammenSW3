using OOPEksammenSW3.Transactions;
using OOPEksammenSW3.Products;
using OOPEksammenSW3.Users;
using System;

namespace OOPEksammenSW3
{
    internal interface IStregsystemUI
    {
        event EventHandler<string> CommandEntered;
        void DisplayUserNotFound(string username);
        void DisplayProductNotFound(string product);
        void DisplayUserInfo(User user);
        void DisplayTooManyArgumentsError(string command);
        void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        void DisplayInsufficientCash(User user, Product product);
        void DisplayGeneralError(string errorString);
        void Start();
    }
}