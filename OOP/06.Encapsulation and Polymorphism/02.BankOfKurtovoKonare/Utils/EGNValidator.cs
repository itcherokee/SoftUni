namespace Banking.Utils
{
    using System;
    using System.Globalization;
    using System.Text;

    public static class EgnValidator
    {
        /// <summary>
        /// Checks does EGN is valid one.
        /// </summary>
        /// <param name="egn">EGN to be checked for validity.</param>
        /// <returns>True if EGN is valid, otherwise returns false</returns>
        public static bool IsValid(string egn)
        {
            return egn.Length == 10 && IsOnlyDigits(egn) && IsValidDate(egn) && IsValidControlSum(egn);
        }

        /// <summary>
        /// Checks does EGN is made only by digits.
        /// </summary>
        /// <param name="egn">EGN to be checked.</param>
        /// <returns>True if only digits, otherwise return false.</returns>
        private static bool IsOnlyDigits(string egn)
        {
            // if only digits inside, we are OK to proceed
            uint digits;
            return uint.TryParse(egn, out digits) ? true : false;
        }

        /// <summary>
        /// Checks does the control sum within EGN is OK.
        /// </summary>
        /// <param name="egn">EGN to be checked.</param>
        /// <returns>True if the control sum is OK otherwise return false.</returns>
        private static bool IsValidControlSum(string egn)
        {
            int[] koeficient = { 2, 4, 8, 5, 10, 9, 7, 3, 6, 0 };
            var cifri = new int[2, egn.Length];
            for (int index = 0; index < 10; index++)
            {
                cifri[0, index] = byte.Parse(egn[index].ToString(CultureInfo.InvariantCulture));
                cifri[1, index] = cifri[0, index] * koeficient[index];
            }

            int sum = 0;
            for (int index = 0; index < 9; index++)
            {
                sum += cifri[1, index];
            }

            sum = (sum % 11) == 10 ? 0 : sum % 10;
            if (sum.Equals(cifri[0, 9]))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check does date within the EGN is valid.
        /// </summary>
        /// <param name="egn">EGN to be checked.</param>
        /// <returns>True - if date within EGN is valid, otherwise return false.</returns>
        private static bool IsValidDate(string egn)
        {
            byte month = byte.Parse(egn.Substring(2, 2));
            string year = egn.Substring(0, 2);
            var date = new StringBuilder();
            date.Append(egn.Substring(4, 2));
            date.Append(".");
            if (month % 10 == 2 || month % 10 == 3)
            {
                date.Append(20 - month);
                date.Append(".");
                date.Append(18);
                date.Append(year);
            }
            else if (month % 10 == 4 || month % 10 == 5)
            {
                date.Append(40 - month);
                date.Append(".");
                date.Append(20);
                date.Append(year);
            }
            else
            {
                date.Append(egn.Substring(2, 2));
                date.Append(".");
                date.Append(19);
                date.Append(year);
            }

            DateTime temp;
            if (DateTime.TryParse(date.ToString(), out temp))
            {
                return true;
            }

            return false;
        }
    }
}