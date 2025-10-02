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
var browserLang = await js.InvokeAsync<string>("eval", "navigator.language");

var supportedCultures = new[] { "en-US", "es-ES" };
string cultureName = supportedCultures[0];
if (!string.IsNullOrWhiteSpace(browserLang))
{
    var lang = browserLang.Split('-')[0];
    cultureName = lang == "es" ? supportedCultures[1] : supportedCultures[0];
}

var culture = new CultureInfo(browserLang);
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
