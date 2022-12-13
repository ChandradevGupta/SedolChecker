using SedolInterfaces;

namespace SedolChecker
{
    public class SedolValidator : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string input)
        {
            var sedol = new Sedol(input);

            var result = new SedolValidationResult
            {
                InputString = input,
                IsValidSedol = false,
                IsUserDefined = false,
                ValidationDetails = null
            };

            if (!sedol.IsValidLength())
            {
                result.ValidationDetails = ErrorMessages.INVALID_LENGTH;
                return result;
            }
            if (!sedol.IsAlphaNumeric())
            {
                result.ValidationDetails = ErrorMessages.INVALIDCHARS;
                return result;
            }
            if (sedol.IsUserDefined())
            {
                result.IsUserDefined = true;
                if (sedol.HasValidCheckDigit())
                {
                    result.IsValidSedol = true;
                    return result;
                }
                result.ValidationDetails = ErrorMessages.CHECKSUM_NOT_VALID;
                return result;
            }

            if (sedol.HasValidCheckDigit())
                result.IsValidSedol = true;
            else
                result.ValidationDetails = ErrorMessages.CHECKSUM_NOT_VALID;

            return result;
        }
    }
}
