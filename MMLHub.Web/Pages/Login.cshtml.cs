using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MMLHub.Web.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string DemoUser { get; set; } = string.Empty;

    public void OnGet()
    {
        ViewData["FullWidth"] = true;
    }

    public IActionResult OnPost()
    {
        switch (DemoUser)
        {
            case "admin":
                HttpContext.Session.SetString("UserName", "MML Admin");
                HttpContext.Session.SetString("Role", "MMLAdmin");
                HttpContext.Session.SetInt32("ClientId", 0);
                break;

            case "client-a":
                HttpContext.Session.SetString("UserName", "Client A User");
                HttpContext.Session.SetString("Role", "ClientUser");
                HttpContext.Session.SetInt32("ClientId", 1);
                break;

            case "client-b":
                HttpContext.Session.SetString("UserName", "Client B User");
                HttpContext.Session.SetString("Role", "ClientUser");
                HttpContext.Session.SetInt32("ClientId", 2);
                break;

            default:
                return Page();
        }

        return RedirectToPage("/Index");
    }
}