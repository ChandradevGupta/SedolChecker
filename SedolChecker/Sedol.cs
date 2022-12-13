using System.Globalization;
using System.Text.RegularExpressions;

namespace SedolChecker
{
    public class Sedol
    {
        private readonly string _value;
        private readonly List<int> _weights;
        private const int CHECK_DIGIT_IDX = 6;
        private const int SEDOL_LENGTH = 7;

        public Sedol(string input)
        {
            _weights = new List<int> { 1, 3, 1, 7, 3, 9 };
            _value = input;
        }

        public static int Code(char input)
        {
            if (Char.IsLetter(input))
                return Char.ToUpper(input) - 55;
            return input - 48;
        }

        public char CheckDigit()
        {
            var codes = _value.Take(SEDOL_LENGTH - 1).Select(Code).ToList();
            int weightedSum = 0;

            for (int i = 0; i < codes.Count; i++)
            {
                weightedSum += codes[i] * _weights[i];
            }
            return Convert.ToChar(((10 - (weightedSum % 10)) % 10).ToString(CultureInfo.InvariantCulture));
            
        }

        public bool IsAlphaNumeric()
        {
             return Regex.IsMatch(_value, "^[a-zA-Z0-9]*$");
        }

     
        public bool IsValidLength()
        {
             return !String.IsNullOrEmpty(_value) && _value.Length == SEDOL_LENGTH; 
        }

        public bool IsUserDefined()
        {
             return _value[0] == '9'; 
        }

        public bool HasValidCheckDigit()
        {
             return _value[CHECK_DIGIT_IDX] == CheckDigit();
        }

    }
}
