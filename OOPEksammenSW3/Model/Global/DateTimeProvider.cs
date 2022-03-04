using System;

namespace OOPEksammenSW3.Model.Global
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now { get => DateTime.Now; }
    }
}