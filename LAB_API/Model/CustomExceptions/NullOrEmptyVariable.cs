namespace LAB_API.Model
{
    public static class NullOrEmptyVariable : Exception
    {
        private const string DefaultErrorMessage = "Null or empty parameter";

        public NullOrEmptyVariable(string message = DefaultErrorMessage): base(message){}

        public static void ThrowIfNull(string? item,string message = DefaultErrorMessage)
        {
            if(string.IsNullOrEmpty(item))
                throw new NullOrEmptyVariable(message);
        }
    }
}