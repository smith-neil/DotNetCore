namespace DotNetCore.Core
{
    public interface IIdentifiable<T>
    {
        T Id { get; set; }
    }
}
