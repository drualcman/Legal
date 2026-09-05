using Legal.Localization;
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

if (cultureName == "tl") cultureName = "fil";
// "fil" antes que "fr" o "it": el idioma guardado se compara por prefijo, así que el catálogo manda
// y aquí sólo se busca la primera entrada que encaje.
var matched = SupportedLanguages.All.FirstOrDefault(language =>
    cultureName.StartsWith(language.Code, StringComparison.OrdinalIgnoreCase))?.Code ?? "es";

var culture = new CultureInfo(matched);
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
