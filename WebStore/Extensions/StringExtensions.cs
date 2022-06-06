using System.Globalization;

namespace WebStore.Extensions
{
    public static class StringExtensions
    {
        public static decimal ToDecimal(this string target, out bool isDecimal)
        {
            var result = default(decimal);
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            isDecimal = decimal.TryParse(target, style, culture, out result);

            return result;
        }

        public static double ToDouble(this string target, out bool isDouble)
        {
            var result = default(double);
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            isDouble = double.TryParse(target, style, culture, out result);

            return result;
        }

        public static decimal ToDoubleFormat(this string target, out bool isDecimal)
        {
            var result = default(decimal);
            var style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            isDecimal = decimal.TryParse(target, style, culture, out result);

            return result;
        }

        public static string ToInputNumber(this string target)
        {
            return String.Format(new CultureInfo("en-US"), "{0:0.##}", target);
        }
    }
}
