using Bala.Web.Components;

#region Configue the web server host and services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents();
var app = builder.Build();
#endregion

#region Configure the HTTP request pipeline and routes
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapRazorComponents<App>();
app.MapGet("/env", () => 
    $"Environment is {app.Environment.EnvironmentName}");
#endregion

app.Run();