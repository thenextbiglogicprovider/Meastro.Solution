using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents the Base Model Extension Class
/// </summary>
namespace Web.App.Business.Extensions
{
    /// <summary>
    /// The Base Model Extension Class
    /// </summary>
    public static class BaseModelExtension
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public static string ToString(this string str, IFormatProvider format)
        {
            return str.ToString(format);
        }

        /// <summary>
        /// To the locale date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string ToLocaleDateTime(this DateTime dateTime, CultureInfo culture)
        {
            return dateTime.ToLocaleDateTime(culture);
        }

        /// <summary>
        /// To the serialized data.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        /// <exception cref="JsonSerializationException"></exception>
        public static string ToSerializedData(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch

            {
                throw new JsonSerializationException();
            }
        }

        /// <summary>
        /// To the object.
        /// </summary>
        /// <param name="serializedData">The serialized data.</param>
        /// <returns></returns>
        /// <exception cref="JsonSerializationException"></exception>
        public static Object ToObject(this string serializedData)
        {
            try
            {
                return JsonConvert.DeserializeObject(serializedData);
            }
            catch
            {
                throw new JsonSerializationException();
            }
        }

        /// <summary>
        /// To the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The Number representation
        /// </returns>
        /// <exception cref="System.InvalidCastException"></exception>
        public static int ToNumber(this string number)
        {
            try
            {
                return Convert.ToInt32(number);
            }
            catch
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// To the decimal.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The Decimal representation
        /// </returns>
        /// <exception cref="System.InvalidCastException"></exception>
        public static decimal ToDecimal(this string number)
        {
            try
            {
                return Convert.ToDecimal(number);
            }
            catch
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// To the decimal.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The Decimal representation
        /// </returns>
        /// <exception cref="System.InvalidCastException"></exception>
        public static decimal ToDecimal(this int number)
        {
            try
            {
                return Convert.ToDecimal(number);
            }
            catch
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// To the double.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The Double floating point representation
        /// </returns>
        /// <exception cref="System.InvalidCastException"></exception>
        public static double ToDouble(this string number)
        {
            try
            {
                return Convert.ToDouble(number);
            }
            catch
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// To the float.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="fixedPlaces">The fixed places.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidCastException"></exception>
        public static float ToFloat(this string number, int fixedPlaces = 0)
        {
            try
            {
                return fixedPlaces > 0 ? float.Parse(Decimal.Round(ToDecimal(number), fixedPlaces).ToString()) : float.Parse(number);
            }
            catch
            {
                throw new InvalidCastException();
            }
        }

        /// <summary>
        /// To the date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>
        /// The DateTime representation
        /// </returns>
        /// <exception cref="System.InvalidCastException"></exception>
        public static DateTime ToDateTime(this string dateTime)
        {
            try
            {
                return Convert.ToDateTime(dateTime);
            }
            catch
            {
                throw new InvalidCastException();
            }
        }
    }
}
