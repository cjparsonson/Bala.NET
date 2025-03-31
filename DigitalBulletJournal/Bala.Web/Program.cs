using Bala.DataContext.Sqlite;
using Bala.Services;

#region Configue the web server host and services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddJournalDbContext();
// Register the JournalService with its interface
builder.Services.AddScoped<IJournalService, JournalService>();
var app = builder.Build();
#endregion

#region Configure the HTTP request pipeline and routes
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();
app.UseDefaultFiles();
app.MapRazorPages();
app.MapGet("/env", () => 
    $"Environment is {app.Environment.EnvironmentName}");
#endregion

app.Run();