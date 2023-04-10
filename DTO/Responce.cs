namespace TestCatalogue.DTO
{
    public class Responce<T>
    {
        public List<T>? Body { get; set; }

        public Responce()
        {
            Body = new List<T>();
        }
    }
}
