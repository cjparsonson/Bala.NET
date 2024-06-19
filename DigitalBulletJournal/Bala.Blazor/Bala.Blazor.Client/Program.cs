using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Bala.Shared;


var builder = WebAssemblyHostBuilder.CreateDefault(args);


await builder.Build().RunAsync();
