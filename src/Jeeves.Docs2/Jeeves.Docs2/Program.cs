using Jeeves.Docs2.Models;
using Jeeves.Docs2.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Jeeves.Docs2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var path = builder.Configuration["ServerUrl"];
            if (!string.IsNullOrWhiteSpace(path))
                path = builder.HostEnvironment.BaseAddress + path;

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(path) });

            builder.Services.AddSingleton<Settings>();

            builder.Services.AddSingleton<HomePageStaticTexts>();

            builder.Services.AddSingleton<LocaleStaticTexts>();

            builder.Services.AddScoped<IDataService, DataService>();

            builder.Services.AddScoped<IJavaScript, JavaScriptService>();

            builder.Services.AddScoped<ILocalStorage, LocalStorageService>();

            //builder.Services.AddDevExpressBlazor();

            await builder.Build().RunAsync();
        }
    }
}
