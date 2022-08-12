namespace RulesPattern.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToValueOrDefault(
            this DateTime? dateTime,
            DateTime? defaultValue = null
        )
        {
            defaultValue ??= DateTime.Now;
            return dateTime ?? defaultValue.Value;
        }
    }
}
