namespace OOPEksammenSW3.Exceptions
{
    [System.Serializable]
    public class UserNotExist : System.Exception
    {
        public UserNotExist() { }
        public UserNotExist(string message) : base(message) { }
        public UserNotExist(string message, System.Exception inner) : base(message, inner) { }
        protected UserNotExist(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}