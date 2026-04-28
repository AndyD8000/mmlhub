using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMLHub.Web.Models;
using MMLHub.Web.Services;

namespace MMLHub.Web.Pages;

public class WorkOrderDetailsModel : PageModel
{
    private readonly IWorkOrderService _service;

    public WorkOrderDetailsModel(IWorkOrderService service)
    {
        _service = service;
    }

    public WorkOrder? WorkOrder { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        WorkOrder = await _service.GetWorkOrderByIdAsync(id);

        if (WorkOrder == null)
        {
            return NotFound();
        }

        return Page();
    }
}