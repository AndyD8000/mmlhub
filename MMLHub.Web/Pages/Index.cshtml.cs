using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MMLHub.Web.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
        ViewData["FullWidth"] = true;
    }
}
