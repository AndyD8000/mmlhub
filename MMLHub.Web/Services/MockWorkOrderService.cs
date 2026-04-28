using MMLHub.Web.Models;

namespace MMLHub.Web.Services;

public class MockWorkOrderService : IWorkOrderService
{
    public Task<List<WorkOrder>> GetWorkOrdersAsync()
    {
        return Task.FromResult(InMemoryWorkOrderStore.WorkOrders);
    }

    public async Task<WorkOrder?> GetWorkOrderByIdAsync(int id)
    {
        var workOrders = await GetWorkOrdersAsync();
        return workOrders.FirstOrDefault(x => x.Id == id);
    }
}