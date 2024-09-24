namespace Shop.UserRegistrationService.Entities
{
    public class UserRegistrationEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string LocationRegistration { get; set; } = string.Empty;
        public DateTime DataRegistration { get; set; }
    }
}
