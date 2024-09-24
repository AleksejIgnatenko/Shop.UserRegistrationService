namespace Shop.UserRegistrationService.DTO
{
    [Serializable]
    public class UserModelDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
