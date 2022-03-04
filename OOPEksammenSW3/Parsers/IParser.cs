using System.Collections.Generic;
using OOPEksammenSW3.Model.Global;

namespace OOPEksammenSW3.Parsers
{
    public interface IParser<T>
    {
        IList<T> Parse(IEnumerable<string> lines, IIdProvider idProvider);
    }
}