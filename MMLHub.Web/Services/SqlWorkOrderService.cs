using Microsoft.Data.SqlClient;
using MMLHub.Web.Models;

namespace MMLHub.Web.Services;

public class SqlWorkOrderService : IWorkOrderService
{
    private readonly IConfiguration _configuration;

    public SqlWorkOrderService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<List<WorkOrder>> GetWorkOrdersAsync()
    {
        var connectionString = _configuration.GetConnectionString("WorkOrdersDb");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Missing connection string: WorkOrdersDb");
        }

        var workOrders = new List<WorkOrder>();

        const string sql = """
            SELECT TOP 50
                work_order_number,
                client_reference,
                client_name,
                site_description,
                category,
                wo_status,
                created_date
            FROM dbo.vw_WorkOrderDataDetails
            ORDER BY created_date DESC
            """;

        await using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        await using var command = new SqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            workOrders.Add(new WorkOrder
            {
                Id = reader.GetInt32(0),
                Reference = reader.GetString(1),
                ClientName = reader.GetString(2),
                SiteName = reader.GetString(3),
                Description = reader.GetString(4),
                Status = reader.GetString(5),
                LoggedDate = reader.GetDateTime(6)
            });
        }

        return workOrders;
    }
}