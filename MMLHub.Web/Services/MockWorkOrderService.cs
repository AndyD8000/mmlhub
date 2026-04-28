using MMLHub.Web.Models;

namespace MMLHub.Web.Services;

public class MockWorkOrderService : IWorkOrderService
{
    public Task<List<WorkOrder>> GetWorkOrdersAsync()
    {
        var workOrders = new List<WorkOrder>
        {
            new()
            {
                Id = 1,
                Reference = "WO-1001",
                ClientName = "Test Client A",
                SiteName = "Main Office",
                Description = "Heating issue reported",
                Status = "Open",
                LoggedDate = DateTime.Today.AddDays(-2)
            },
            new()
            {
                Id = 2,
                Reference = "WO-1002",
                ClientName = "Test Client B",
                SiteName = "Warehouse",
                Description = "Lighting fault",
                Status = "In Progress",
                LoggedDate = DateTime.Today.AddDays(-1)
            },
            new()
            {
                Id = 3,
                Reference = "WO-1003",
                ClientName = "Test Client A",
                SiteName = "Reception",
                Description = "Door access issue",
                Status = "Closed",
                LoggedDate = DateTime.Today
            }
        };

        return Task.FromResult(workOrders);
    }
}

public async Task<WorkOrder?> GetWorkOrderByIdAsync(int id)
{
    var workOrders = await GetWorkOrdersAsync();
    return workOrders.FirstOrDefault(x => x.Id == id);
}