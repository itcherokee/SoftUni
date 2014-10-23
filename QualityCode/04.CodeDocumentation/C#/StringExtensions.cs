namespace StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension methods library for String type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Compute a MD5 hash value of a string.
        /// </summary>
        /// <param name="input">String which MD5 hash to be calculated.</param>
        /// <returns>MD5 hash value of the current string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Checks does string represents a valid boolean value.
        /// </summary>
        /// <param name="input">String to be checked for valid boolean value.</param>
        /// <returns>True - if string is valid boolean value else returns False.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Tries to convert the string to Short type value.
        /// </summary>
        /// <param name="input">String to be converted to Short type.</param>
        /// <returns>Short type value if conversion is successful else returns zero (0).</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Tries to convert the string to Int32 (int) type value.
        /// </summary>
        /// <param name="input">String to be converted to Int32 type.</param>
        /// <returns>Int32 type value if conversion is successful else returns zero (0).</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Tries to convert the string to Int64 (long) type value.
        /// </summary>
        /// <param name="input">String to be converted to Int64 type.</param>
        /// <returns>Int64 type value if conversion is successful else returns zero (0).</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Tries to convert the string to DateTime type value.
        /// </summary>
        /// <param name="input">String to be converted to DateTime type.</param>
        /// <returns>DateTyme type value (represented in string) if conversion is successful 
        /// else returns "1.1.0001 00:00:00".
        /// </returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Converts string into Sentence style capitalization (first letter Capital).
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Sentence like style capitalized string.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return
                input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
                input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Retrieves a substring from the current instance which is surrounded by start and end strings.
        /// </summary>
        /// <param name="input">String to be used for extraction of substring.</param>
        /// <param name="startString">Substring to be used as starting border.</param>
        /// <param name="endString">Substring to be used as end border.</param>
        /// <param name="startFrom">Zero based starting position for lookup of start substring.</param>
        /// <returns>Extracted substring if found else string.Empty.</returns>
        public static string GetStringBetween(
            this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition =
                input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts current instance cyrilic letters to latin ones using phonetic translation.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Converted to latin letters only string.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
            {
                "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
                "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
            };
            var latinRepresentationsOfBulgarianLetters = new[]
            {
                "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
            };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(
                    bulgarianLetters[i].ToUpper(),
                    latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts current instance latin letters to cyrilic ones using phonetic translation.
        /// </summary>
        /// <param name="input">String to be converted.</param>
        /// <returns>Converted to cyrilic letters only string.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            var bulgarianRepresentationOfLatinKeyboard = new[]
            {
                "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                "в", "ь", "ъ", "з"
            };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(
                    latinLetters[i].ToUpper(),
                    bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts current instance to valid latin letters based user name.
        /// </summary>
        /// <param name="input">String to be validated and converted.</param>
        /// <returns>Valid for user name string.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts current instance to valid latin letters based file name.
        /// </summary>
        /// <param name="input">String to be validated and converted.</param>
        /// <returns>Valid for file name string.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Retrieves specified number of chars from the bigining of a current instance.
        /// </summary>
        /// <param name="input">String to be used for retrieval.</param>
        /// <param name="charsCount">Number of chars to be retrieved.</param>
        /// <returns>Specified number of chars from the begining of string as a string.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Retrieves file name extension.
        /// </summary>
        /// <param name="fileName">String representing valid file name.</param>
        /// <returns>File extension as a string, if not found returns empty string.</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts an string representing file extension to coresponding content type.
        /// </summary>
        /// <param name="fileExtension">String representing file extension.</param>
        /// <returns>Content type based on standards.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
            {
                { "jpg", "image/jpeg" },
                { "jpeg", "image/jpeg" },
                { "png", "image/x-png" },
                { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                { "doc", "application/msword" },
                { "pdf", "application/pdf" },
                { "txt", "text/plain" },
                { "rtf", "application/rtf" }
            };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Convertsa an instance to byte array representation.
        /// </summary>
        /// <param name="input">String to be converted to Byte array.</param>
        /// <returns>Byte array consisting string representation as bytes.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
