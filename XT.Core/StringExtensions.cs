using static System.Char;

namespace XT.Core
{
    public static class StringExtensions
    {

        public static bool IsAllUpper(this string? input)
        {
            if (input == null) return false;
            for (int i = 0; i < input.Length; i++)
            {
                if (IsLetter(input[i]) && !IsUpper(input[i]))
                    return false;
            }
            return true;
        }

        public static bool IsAllLower(this string? input)
        {
            if (input == null) return false;
            for (int i = 0; i < input.Length; i++)
            {
                if (IsLetter(input[i]) && !IsLower(input[i]))
                    return false;
            }
            return true;
        }
    }
}
