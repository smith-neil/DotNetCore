namespace DotNetCore.Core.Utilities
{
    public static class IIdentifiableUtils
    {
        public static bool IsNew<T>(this IIdentifiable<T> source)
        {
            source.ThrowIfNull("source");

            return Equals(source.Id, default(T));
        }
    }
}
