using Jeeves.Docs.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Jeeves.Docs.Pages
{
	/// <summary>
	/// Field component.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
	public partial class Field
	{
		/// <summary>
		/// Gets or sets the field identifier.
		/// </summary>
		[Parameter]
		public string FieldId { get; set; }

		/// <summary>
		/// Gets or sets the field items.
		/// </summary>
		public DocsAgent.Models.Field Contents { get; set; }

		/// <summary>
		/// Gets or sets the data service.
		/// </summary>
		[Inject]
		public IDataService DataService { get; set; }

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
			Contents = await DataService.GetField(fieldId: FieldId);
			await base.OnParametersSetAsync();
		}
	}
}