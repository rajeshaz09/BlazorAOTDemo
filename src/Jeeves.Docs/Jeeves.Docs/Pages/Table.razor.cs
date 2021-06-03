using Jeeves.Docs.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Jeeves.Docs.Pages
{
	/// <summary>
	/// Table component
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
	public partial class Table
	{
		/// <summary>
		/// Gets or sets the table identifier.
		/// </summary>
		[Parameter]
		public string TableId { get; set; }

		/// <summary>
		/// Gets or sets the data service.
		/// </summary>
		[Inject]
		public IDataService DataService { get; set; }

		/// <summary>
		/// Gets or sets the table contents.
		/// </summary>
		public DocsAgent.Models.Table TableContents { get; set; }

		/// <summary>
		/// Gets or sets the locale static texts.
		/// </summary>
		[Inject]
		public LocaleStaticTexts LocaleStaticTexts { get; set; }

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			TableContents = await DataService.GetTable(TableId);
			await base.OnParametersSetAsync();
		}
	}
}
