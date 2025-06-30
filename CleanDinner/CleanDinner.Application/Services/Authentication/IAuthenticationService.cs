
public interface IAuthenticationService
{   AuthenticationResult Login(string Email, string Password);
    AuthenticationResult Register(string firstName, string lastName, string email, string password);
}