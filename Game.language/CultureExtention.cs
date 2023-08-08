using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;


namespace Game.language
{
    public static class CultureExtention
    {
        public static async Task AddCulture(this WebAssemblyHostBuilder builder)
        {
            var host = builder.Build();
            var js = host.Services.GetRequiredService<CultureJsInterop>();
            var result = await js.GetBlazorCulture();
            CultureInfo culture;
            if (result != null)
            {
                culture = new CultureInfo(result);
            }
            else
            {
                culture = new CultureInfo("en-US");
                js.SetBlazorCulture("en-US");
            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }

}
