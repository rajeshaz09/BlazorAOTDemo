using DevExpress.Blazor;
using Jeeves.Docs.Models;
using Jeeves.DocsAgent.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Jeeves.Docs.Shared
{
	/// <summary>
	/// Field data grid razor component.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "<Pending>")]
	public partial class FieldsGrid
	{
		/// <summary>
		/// Gets or sets the fields.
		/// </summary>
		[Parameter]
		public Fields Fields { get; set; }

		/// <summary>
		/// Gets or sets the locale static texts.
		/// </summary>
		[Inject]
		public LocaleStaticTexts LocaleStaticTexts { get; set; }

		/// <summary>
		/// Gets or sets the fields data grid.
		/// </summary>
		public DxDataGrid<Field> FieldsDataGrid { get; set; }

		/// <summary>
		/// Gets or sets the navigation manager.
		/// </summary>
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		/// <summary>
		/// Called when the row has been selected.
		/// </summary>
		/// <param name="field">The field.</param>
		protected void OnSelectedFieldChanged(Field field)
		{
			if (field == null)
				throw new ArgumentNullException(nameof(field));
			NavigationManager.NavigateTo("/Field/" + field.Id);
		}

		/// <summary>
		/// Method invoked after each time the component has been rendered. Note that the component does
		/// not automatically re-render after the completion of any returned <see cref="T:System.Threading.Tasks.Task" />, because
		/// that would cause an infinite render loop.
		/// </summary>
		/// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
		/// on this component instance; otherwise <c>false</c>.</param>
		protected override Task OnAfterRenderAsync(bool firstRender)
		{
			if (Fields != null && Fields.FieldCollection.Count < 10)
			{
				FieldsDataGrid.ShowPager = false;
			}
			return base.OnAfterRenderAsync(firstRender);
		}
	}
}
