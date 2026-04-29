using Microsoft.AspNetCore.Http;

namespace MMLHub.Web.Services;

public class CurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ISession? Session => _httpContextAccessor.HttpContext?.Session;

    public string UserName => Session?.GetString("UserName") ?? "Not signed in";
    public string Role => Session?.GetString("Role") ?? "Guest";
    public int ClientId => Session?.GetInt32("ClientId") ?? 0;

    public bool IsSignedIn => Role != "Guest";
    public bool IsAdmin => Role == "MMLAdmin";
}