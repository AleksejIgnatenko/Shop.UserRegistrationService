namespace Shop.UserRegistrationService.Contracts
{
    public record UsersRequest(
        string UserName,
        string Email,
        string Telephone,
        string Password,
        string LocationRegistration
        );
}
