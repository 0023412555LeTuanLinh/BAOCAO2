using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MyBlazorApp;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// MudBlazor
builder.Services.AddMudServices();

// HttpClient trỏ tới API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7260/") });

await builder.Build().RunAsync();
