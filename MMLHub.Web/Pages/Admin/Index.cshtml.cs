using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMLHub.Web.Services;

namespace MMLHub.Web.Pages.Admin;

public class IndexModel : PageModel
{
    private readonly CurrentUserService _currentUser;

    public IndexModel(CurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public IActionResult OnGet()
    {
        if (!_currentUser.IsAdmin)
        {
            //return Forbid();
            return RedirectToPage("/AccessDenied");
        }

        return Page();
    }
}