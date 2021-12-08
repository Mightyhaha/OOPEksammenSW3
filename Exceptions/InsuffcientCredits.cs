namespace OOPEksammenSW3.Exceptions
{
    [System.Serializable]
    public class InsufficientCredit : System.Exception
    {
        public InsufficientCredit() { }
        public InsufficientCredit(string message) : base(message) { }
        public InsufficientCredit(string message, System.Exception inner) : base(message, inner) { }
        protected InsufficientCredit(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}