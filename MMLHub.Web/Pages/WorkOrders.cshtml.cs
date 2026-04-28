using Microsoft.AspNetCore.Mvc.RazorPages;
using MMLHub.Web.Models;
using MMLHub.Web.Services;

namespace MMLHub.Web.Pages;

public class WorkOrdersModel : PageModel
{
    private readonly IWorkOrderService _workOrderService;

    public WorkOrdersModel(IWorkOrderService workOrderService)
    {
        _workOrderService = workOrderService;
    }

    public List<WorkOrder> WorkOrders { get; set; } = new();

    public async Task OnGetAsync()
    {
        WorkOrders = await _workOrderService.GetWorkOrdersAsync();
    }
}