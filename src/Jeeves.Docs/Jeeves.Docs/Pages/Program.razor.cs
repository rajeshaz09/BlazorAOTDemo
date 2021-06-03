using Jeeves.Docs.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Jeeves.Docs.Pages
{
	/// <summary>
	/// Program component.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
	public partial class Program
	{
		/// <summary>
		/// Gets or sets the program identifier.
		/// </summary>
		[Parameter]
		public string ProgramId { get; set; }

		/// <summary>
		/// Gets or sets the locale static texts.
		/// </summary>
		[Inject]
		public LocaleStaticTexts LocaleStaticTexts { get; set; }

		/// <summary>
		/// Gets or sets the data service.
		/// </summary>
		[Inject]
		public IDataService DataService { get; set; }

		/// <summary>
		/// Gets or sets the program contents.
		/// </summary>
		public DocsAgent.Models.Program ProgramContents { get; set; }

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			ProgramContents = await DataService.GetProgram(ProgramId);
			await base.OnParametersSetAsync();
		}
	}
}
