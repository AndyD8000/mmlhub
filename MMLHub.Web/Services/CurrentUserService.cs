namespace MMLHub.Web.Services;

public class CurrentUserService
{
    public string UserName => "Test User";
    public string Role => "ClientUser"; // change to "MMLAdmin" to test admin mode
    public int ClientId => 1;

    public bool IsAdmin => Role == "MMLAdmin";
}