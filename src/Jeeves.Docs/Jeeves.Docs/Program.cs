using Jeeves.Docs.Models;
using Jeeves.Docs.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jeeves.Docs
{
	/// <summary>
	/// Starting point of the app
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<Pending>")]
	public class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
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

			builder.Services.AddDevExpressBlazor();
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
			await builder.Build().RunAsync();
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
		}
	}
}
