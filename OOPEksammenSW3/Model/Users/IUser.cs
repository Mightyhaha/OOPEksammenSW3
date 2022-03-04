using System;
using OOPEksammenSW3.Model.Global;

namespace OOPEksammenSW3.Model.Users
{
    public interface IUser
    {
        int Id { get; }
        Username Username { get; }
        DanskKrone Balance { get; set; }

        event EventHandler<EventArgs> BelowBalanceThreshold;

        int CompareTo(User other);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}