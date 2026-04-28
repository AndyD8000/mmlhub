using MMLHub.Web.Models;

namespace MMLHub.Web.Services;

public static class InMemoryWorkOrderStore
{
    public static List<WorkOrder> WorkOrders { get; } = new()
    {
        new()
        {
            Id = 1,
            Reference = "WO-1001",
            ClientName = "Test Client A",
            SiteName = "Main Office",
            Description = "Heating issue",
            Status = "Open",
            LoggedDate = DateTime.Now
        }
    };

    public static int NextId => WorkOrders.Count + 1;

    public static List<Client> Clients { get; } = new()
    {
        new() { Id = 1, Name = "Client A" },
        new() { Id = 2, Name = "Client B" }
    };

}