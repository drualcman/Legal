using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Legal.App>("#app");
builder.RootComponents.Add<Microsoft.AspNetCore.Components.Web.HeadOutlet>("head::after");

builder.Services.AddLocalization();

var host = builder.Build();

var js = host.Services.GetRequiredService<IJSRuntime>();
var cultureName = await js.InvokeAsync<string>("getLegalCulture") ?? "es";

string[] supported = ["es", "en", "fil"];
if (cultureName == "tl") cultureName = "fil";
var matched = supported.FirstOrDefault(c =>
    cultureName.StartsWith(c, StringComparison.OrdinalIgnoreCase)) ?? "es";

var culture = new CultureInfo(matched);
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
