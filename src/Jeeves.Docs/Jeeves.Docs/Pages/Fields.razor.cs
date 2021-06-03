using DevExpress.Blazor;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Jeeves.Docs.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jeeves.Docs.Pages
{
	/// <summary>
	/// Fields razor page.
	/// </summary>
	/// <seealso cref="ComponentBase" />
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "<Pending>")]
	public partial class Fields
	{
		#region Private variables
		int _visibleRowCount;
		#endregion

		/// <summary>
		/// The fields collection
		/// </summary>
		public List<DocsAgent.Models.Field> FieldCollection { get; set; } = new List<DocsAgent.Models.Field>();

		/// <summary>
		/// Gets or sets the locale static texts.
		/// </summary>
		[Inject]
		LocaleStaticTexts LocaleStaticTexts { get; set; }

		/// <summary>
		/// Gets or sets the data service.
		/// </summary>
		[Inject]
		IDataService DataService { get; set; }

		/// <summary>
		/// Gets or sets the settings.
		/// </summary>
		[Inject]
		Settings Settings { get; set; }

		/// <summary>
		/// Gets or sets the visible row count.
		/// </summary>
		public int VisibleRowCount
		{
			get
			{
				return _visibleRowCount;
			}
			set
			{
				_visibleRowCount = value;
				InvokeAsync(StateHasChanged);
			}
		}

		/// <summary>
		/// Gets or sets the navigation manager.
		/// </summary>
		[Inject]
		NavigationManager NavigationManager { get; set; }

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			var fields = await DataService.GetFields();
			FieldCollection = fields.FieldCollection;
			await base.OnParametersSetAsync();
		}

		/// <summary>
		/// Loads the custom data.
		/// </summary>
		/// <param name="options">The options.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>Returns the load result<see cref="LoadResult"/></returns>
		protected async Task<LoadResult> LoadCustomData(DataSourceLoadOptionsBase options, CancellationToken cancellationToken)
		{
			await WaitUntilDataIsInitialized(cancellationToken);
			LoadResult result = DataSourceLoader.Load(FieldCollection, options);
			VisibleRowCount = result.totalCount;
			return result;
		}

		/// <summary>
		/// Called when the row has been selected.
		/// </summary>
		/// <param name="field">The field.</param>
		protected void OnSelectedFieldChanged(DocsAgent.Models.Field field)
		{
			if (field == null)
				throw new ArgumentNullException(nameof(field));
			NavigationManager.NavigateTo("/Field/" + field.Id);
		}

		/// <summary>
		/// Waits the until data is initialized.
		/// </summary>
		/// <param name="cancellationToken">The cancellation token.</param>
		private async Task WaitUntilDataIsInitialized(CancellationToken cancellationToken)
		{
			while (FieldCollection.Count == 0)
			{
				await Task.Delay(100, cancellationToken);
			}
		}

		/// <summary>
		/// Saves the grid's information when the layout has been changed.
		/// </summary>
		/// <param name="dataGridLayout">Data grid layout<see cref="IDataGridLayout"/></param>
		void OnLayoutChanged(IDataGridLayout dataGridLayout)
		{
			var layout = dataGridLayout.SaveLayout();
			Settings.FieldsLayoutInformation = layout;
		}

		/// <summary>
		/// Restores the grid's information from the storage.
		/// </summary>
		/// <param name="dataGridLayout">Data grid layout<see cref="IDataGridLayout"/></param>
		void OnLayoutRestoring(IDataGridLayout dataGridLayout)
		{
			if (!string.IsNullOrWhiteSpace(Settings.FieldsLayoutInformation))
			{
				var layout = Settings.FieldsLayoutInformation;
				dataGridLayout.LoadLayout(layout);
			}
		}
	}
}
