using MMLHub.Web.Models;

namespace MMLHub.Web.Services;

public interface IWorkOrderService
{
    Task<List<WorkOrder>> GetWorkOrdersAsync();
}

Task<WorkOrder?> GetWorkOrderByIdAsync(int id);