namespace SedolChecker
{
    public static class ErrorMessages   
    {
        public const string INVALID_LENGTH = "Input string was not 7-characters long.";
        public const string INVALIDCHARS = "SEDOL contains invalid characters.";
        public const string CHECKSUM_NOT_VALID = "Checksum digit does not agree with the rest of the input.";
    }
}
