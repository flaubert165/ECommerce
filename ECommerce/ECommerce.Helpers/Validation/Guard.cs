using System;
namespace ECommerce.Helpers.Validation
{
    public class Guard
    {

        public static void ForNullOrEmptyDefaultMessage(string value, string propName)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(propName + " é obrigatório!");
        }

        public static void ForNullOrEmpty(string value, string errorMessage)
        {
            if (String.IsNullOrEmpty(value))
                throw new Exception(errorMessage);
        }

        public static void ForNullOrStringWithWhiteSpaces(string value, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception(errorMessage);
        }

        public static void StringLength(string propName, string stringValue, int maximum)
        {
            StringLength(stringValue, maximum, propName + " não pode ter mais que " + maximum + " caracteres");
        }

        public static void StringLength(string stringValue, int maximum, string message)
        {
            int length = stringValue.Length;
            if (length > maximum)
            {
                throw new Exception(message);
            }
        }
        public static void StringLength(string propName, string stringValue, int minimum, int maximum)
        {
            StringLength(stringValue, minimum, maximum, propName + " deve ter de " + minimum + " à " + maximum + " caracteres!");
        }

        public static void StringLength(string stringValue, int minimum, int maximum, string message)
        {
            if (String.IsNullOrEmpty(stringValue))
                stringValue = String.Empty;

            int length = stringValue.Length;
            if (length < minimum || length > maximum)
            {
                throw new Exception(message);
            }
        }

        public static void AreEqual(string a, string b, string errorMessage)
        {
            if (a != b)
                throw new Exception(errorMessage);
        }
    }
}

