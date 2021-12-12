using System;
using OOPEksammenSW3.Global;

namespace OOPEksammenSW3.Users
{
    public interface IUser
    {
        IId<IUser> Id { get; }
        Username Username { get; }
        DanskKrone Balance { get; set; }

        event EventHandler<EventArgs> BelowBalanceThreshold;

        int CompareTo(User other);
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}