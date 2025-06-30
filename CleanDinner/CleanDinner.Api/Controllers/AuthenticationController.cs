using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("login")]
    //public IActionResult Login(string Email, string Password)
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.email, request.password);
        var response = new AuthenticationResponse(

             result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );
        return Ok(response);
    }
    [HttpPost]
    [Route("register")]
    //public IActionResult Register(string firstName, string lastName, string email, string password)
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(request.firstName, request.lastName, request.email, request.password);
        var response = new AuthenticationResponse(

             result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );
        return Ok(response);
    }
}