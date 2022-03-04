using System.Collections.Generic;
using System.Linq;

namespace OOPEksammenSW3.Model.Global
{
    public interface IIdProvider
    {
        public int GetNextId();
        public int TryGetId(int getThis);
    }
}