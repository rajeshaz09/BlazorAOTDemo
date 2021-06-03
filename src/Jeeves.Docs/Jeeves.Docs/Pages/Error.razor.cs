using Jeeves.Docs.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Jeeves.Docs.Pages
{
	/// <summary>
	/// Customized error message.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
	public partial class Error
	{

		/// <summary>
		/// Gets or sets the locale static texts.
		/// </summary>
		[Inject]
		public LocaleStaticTexts LocaleStaticTexts { get; set; }

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[Parameter]
		public string RequestPath { get; set; }

		/// <summary>
		/// Gets or sets the default settings.
		/// </summary>
		[Inject]
		public Settings GlobalSettings { get; set; }

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			while (string.IsNullOrWhiteSpace(LocaleStaticTexts.NoResultsFound))
				await Task.Delay(100);
			RequestPath = GlobalSettings.Error;		
			await base.OnParametersSetAsync();
		}
	}
}
