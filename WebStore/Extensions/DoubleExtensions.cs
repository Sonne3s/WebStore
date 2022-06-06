using System.Globalization;

namespace WebStore.Extensions
{
    public static class DoubleExtensions
    {
        public static string ToInputNumber(this double target)
        {
            return String.Format(new CultureInfo("en-US"), "{0:0.##}", target);
        }
    }
}
