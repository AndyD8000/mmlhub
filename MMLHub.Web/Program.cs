using MMLHub.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<MMLHub.Web.Services.IWorkOrderService, MMLHub.Web.Services.MockWorkOrderService>();

builder.Services.AddScoped<MMLHub.Web.Services.CurrentUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapGet("/api/test", () =>
{
    return new[]
    {
        new { id = 1, job = "Test Job 1", status = "Open" },
        new { id = 2, job = "Test Job 2", status = "Closed" }
    };
});   

app.MapPost("/api/jobs", (WorkOrder job) =>
{
    job.Id = MMLHub.Web.Services.InMemoryWorkOrderStore.NextId;
    job.LoggedDate = DateTime.Now;
    job.ClientName = job.ClientId == 1 ? "Client A" : "Client B";

    MMLHub.Web.Services.InMemoryWorkOrderStore.WorkOrders.Add(job);

    return Results.Ok(new { message = "Job submitted successfully" });
});

app.Run();
