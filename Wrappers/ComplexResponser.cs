
namespace NOWA.Wrappers
{
    public class ComplexResponser <T>
    {

        public bool Success { get; set; }

        public string Message { get; set; }

        public T Content { get; set; }

    }
}