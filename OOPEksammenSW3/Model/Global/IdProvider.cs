using System.Collections.Generic;
using System.Linq;
using System;

namespace OOPEksammenSW3.Model.Global
{
    public class IdProvider : IIdProvider
    {
        List<int> _usedIds = new() { 0 };

        public int GetNextId()
        {
            int nextId = _usedIds.Max() + 1;
            _usedIds.Add(nextId);
            return nextId;
        }

        public int TryGetId(int id)
        {
            if (!_usedIds.Contains(id))
                return id;
            else
                throw new ArgumentException();

        }
    }
}