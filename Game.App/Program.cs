using Game.App;
using Game.WordGame.Services;
using Game.WordGame.Share.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Game.language;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameNotification, GameNotification>();
builder.Services.AddSingleton<PersonService>();
builder.Services.AddScoped<CultureJsInterop>();
builder.Services.AddLocalStorageServices();
builder.Services.AddLocalization();
await builder.AddCulture();
await builder.Build().RunAsync();
