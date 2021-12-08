namespace OOPEksammenSW3.Exceptions
{
    [System.Serializable]
    public class Notactive : System.Exception
    {
        public Notactive() { }
        public Notactive(string message) : base(message) { }
        public Notactive(string message, System.Exception inner) : base(message, inner) { }
        protected Notactive(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}