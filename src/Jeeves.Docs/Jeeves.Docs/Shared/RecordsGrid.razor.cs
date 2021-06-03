using DevExpress.Blazor;
using Jeeves.Docs.Models;
using Jeeves.DocsAgent.Models;
using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Threading.Tasks;

namespace Jeeves.Docs.Shared
{
	/// <summary>
	/// RecordsGrid component.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "<Pending>")]
	public partial class RecordsGrid
	{
		/// <summary>
		/// Gets or sets the Records identifier.
		/// </summary>
		[Parameter]
		public Records Records { get; set; }

		/// <summary>
		/// Gets or sets the page which renders the record grid.
		/// </summary>
		[Parameter]
		public string RenderPage { get; set; }

		/// <summary>
		/// Gets or sets the locale static texts.
		/// </summary>
		[Inject]
		public LocaleStaticTexts LocaleStaticTexts { get; set; }

		/// <summary>
		/// Gets or sets the description presented.
		/// </summary>
		public bool IsDescriptionPresented { get; set; }

		/// <summary>
		/// Gets or sets the records data grid.
		/// </summary>
		public DxDataGrid<Record> RecordsDataGrid { get; set; }

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override Task OnParametersSetAsync()
		{
			if (Records != null && Records.RecordCollection.Count > 0)
			{
				IsDescriptionPresented = Records.RecordCollection.Where(record => !string.IsNullOrWhiteSpace(record.Description)).Any();
			}
			return base.OnParametersSetAsync();
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
			if (Records != null && Records.RecordCollection.Count < 10)
			{
				RecordsDataGrid.ShowPager = false;
			}
			return base.OnAfterRenderAsync(firstRender);
		}
	}
}
