using OOPEksammenSW3.Model.Transactions;
using OOPEksammenSW3.Model.Products;
using OOPEksammenSW3.Model.Users;
using OOPEksammenSW3.Controller.Commands;
using System;

namespace OOPEksammenSW3.View
{
    public interface IStregsystemUI
    {
        event EventHandler<string> CommandEntered;
        // void DisplayUserNotFound(string username);
        // void DisplayProductNotFound(string product);
        void DisplayUserInfo(IUser user);
        // void DisplayTooManyArgumentsError(string command);
        // void DisplayAdminCommandNotFoundMessage(string adminCommand);
        void DisplayUserBuysProduct(BuyTransaction transaction);
        // void DisplayUserBuysProduct(int count, BuyTransaction transaction);
        void Close();
        // void DisplayInsufficientCash(User user, Product product);
        void DisplayGeneralError(string errorString);
        void Start();
    }
}