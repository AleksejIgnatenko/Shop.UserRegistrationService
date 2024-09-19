namespace Shop.UserRegistrationService.CustomException
{
    public class ValidatorException : Exception
    {
        public ValidatorException(string error) : base(error) { }
    }
}
