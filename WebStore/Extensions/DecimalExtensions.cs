using System.Globalization;

namespace WebStore.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToMoney(this decimal target)
        {
            return target.ToString("C", new CultureInfo("ru-RU"));
        }

        public static string ToInputNumber(this decimal target)
        {
            return String.Format(new CultureInfo("en-US"), "{0:0.##}", target);
        }
    }
}
