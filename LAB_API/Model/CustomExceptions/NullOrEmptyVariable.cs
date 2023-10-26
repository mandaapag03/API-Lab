namespace LAB_API.Model
{
    public class NullOrEmptyVariable<T> : Exception
    {
        private const string DefaultErrorMessage = "Null or empty parameter";

        public NullOrEmptyVariable(string message = DefaultErrorMessage): base(message){}

        public static T ThrowIfNull(T? item,string message = DefaultErrorMessage)
        {
            if(item == null)
                throw new NullOrEmptyVariable<T>(message);
            return item;
        }
    }
}