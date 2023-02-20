namespace TestCatalogue.Exceptions
{
    public class NullResultException : Exception
    {
        public override string Message { get; } = "No such position";
    }
}
