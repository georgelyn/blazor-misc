using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Misc;
using Misc.Services;
using System.Globalization;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://pixabay.com/api/") });
builder.Services.AddScoped<IImagesService, ImagesService>();
builder.Services.AddScoped<IMessagesService, MessagesService>();

builder.Services.AddLocalization();

var host = builder.Build();

var js = host.Services.GetRequiredService<IJSRuntime>();
var storedCulture = await js.InvokeAsync<string>("culture.get");
var browserLang = await js.InvokeAsync<string>("browserLanguage");

string cultureName = "en-US";

if (!string.IsNullOrWhiteSpace(storedCulture))
{
    cultureName = storedCulture;
}
else if (!string.IsNullOrWhiteSpace(browserLang) && browserLang.StartsWith("es"))
{
    cultureName = "es-ES";
}

var culture = new CultureInfo(cultureName);
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
