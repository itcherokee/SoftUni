namespace Learn
{
    using System;

    public static class Utils
    {
        public static void ValidateStringInput(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(string.Format("Field {0} cannot be null, empty or blank space!", fieldName));
            }
        }

        public static void ValidateNumericInput(decimal value, string fieldName)
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format("Field {0} cannot be negative!", fieldName));
            }
        }
    }
}
