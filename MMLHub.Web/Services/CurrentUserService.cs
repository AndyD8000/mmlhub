namespace MMLHub.Web.Services;

public class CurrentUserService
{
    public string UserName => "Test User";
    //public string Role => "ClientUser"; // change to "MMLAdmin" to test admin mode
    public string Role => "MMLAdmin";
    public int ClientId => 1;

    public bool IsAdmin => Role == "MMLAdmin";
}