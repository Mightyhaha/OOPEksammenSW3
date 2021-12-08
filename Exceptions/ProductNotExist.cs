namespace OOPEksammenSW3.Exceptions
{
    [System.Serializable]
    public class ProductDoesExist : System.Exception
    {
        public ProductDoesExist() { }
        public ProductDoesExist(string message) : base(message) { }
        public ProductDoesExist(string message, System.Exception inner) : base(message, inner) { }
        protected ProductDoesExist(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}