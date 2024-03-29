namespace OOPEksammenSW3.Model.Global
{
    public class DanskKrone
    {
        protected int _oere;

        public override string ToString()
        {
            return $"{_oere / 100} DDK";
        }

        public static bool operator <(DanskKrone a, DanskKrone b)
        {
            return a._oere < b._oere;
        }

        public static bool operator >(DanskKrone a, DanskKrone b)
        {
            return a._oere > b._oere;
        }

        public static bool operator <=(DanskKrone a, DanskKrone b)
        {
            return a._oere <= b._oere;
        }

        public static bool operator >=(DanskKrone a, DanskKrone b)
        {
            return a._oere >= b._oere;
        }

        public static DanskKrone operator +(DanskKrone a, DanskKrone b)
        {
            int newNumericValue = a._oere + b._oere;
            return new DanskKrone(newNumericValue);
        }

        public static DanskKrone operator -(DanskKrone a, DanskKrone b)
        {
            int newNumericValue = a._oere - b._oere;
            return new DanskKrone(newNumericValue);
        }

        public DanskKrone(int oere)
        {
            _oere = oere;
        }
    }
}