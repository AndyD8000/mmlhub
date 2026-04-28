using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MMLHub.Web.Models;
using MMLHub.Web.Services;

namespace MMLHub.Web.Pages;

public class WorkOrdersModel : PageModel
{
    private readonly IWorkOrderService _service;

    public WorkOrdersModel(IWorkOrderService service)
    {
        _service = service;
    }

    public List<WorkOrder> WorkOrders { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Status { get; set; }

    public int Total => WorkOrders.Count;
    public int Open => WorkOrders.Count(x => x.Status == "Open");
    public int InProgress => WorkOrders.Count(x => x.Status == "In Progress");
    public int Closed => WorkOrders.Count(x => x.Status == "Closed");

    public async Task OnGetAsync()
    {
        var data = await _service.GetWorkOrdersAsync();

        if (!string.IsNullOrWhiteSpace(Search))
        {
            data = data.Where(x =>
                x.Reference.Contains(Search, StringComparison.OrdinalIgnoreCase) ||
                x.Description.Contains(Search, StringComparison.OrdinalIgnoreCase) ||
                x.ClientName.Contains(Search, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        if (!string.IsNullOrWhiteSpace(Status))
        {
            data = data.Where(x => x.Status == Status).ToList();
        }

        WorkOrders = data;
    }
}