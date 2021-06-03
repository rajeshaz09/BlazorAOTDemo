﻿using DevExpress.Blazor;
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
	/// Tables razor page.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "<Pending>")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "<Pending>")]
	public partial class Tables
	{
		#region Private variables
		int _visibleRowCount;
		#endregion

		/// <summary>
		/// The tables collection
		/// </summary>
		public List<DocsAgent.Models.Table> TableCollection { get; set; } = new List<DocsAgent.Models.Table>();

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
		/// Gets or sets the navigation manager.
		/// </summary>
		[Inject]
		NavigationManager NavigationManager { get; set; }

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
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			var tables = await DataService.GetTables();
			TableCollection = tables.TableCollection;
			await base.OnParametersSetAsync();
		}

		/// <summary>
		/// Called when the row has been selected.
		/// </summary>
		/// <param name="table">The table.</param>
		protected void OnSelectedTableChanged(DocsAgent.Models.Table table)
		{
			if (table == null)
				throw new ArgumentNullException(nameof(table));
			NavigationManager.NavigateTo("/Table/" + table.Id);
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
			LoadResult result = DataSourceLoader.Load(TableCollection, options);
			VisibleRowCount = result.totalCount;
			return result;
		}

		/// <summary>
		/// Waits the until data is initialized.
		/// </summary>
		/// <param name="cancellationToken">The cancellation token.</param>
		private async Task WaitUntilDataIsInitialized(CancellationToken cancellationToken)
		{
			while (TableCollection.Count == 0)
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
			Settings.TablesLayoutInformation = layout;
		}

		/// <summary>
		/// Restores the grid's information from the storage.
		/// </summary>
		/// <param name="dataGridLayout">Data grid layout<see cref="IDataGridLayout"/></param>
		void OnLayoutRestoring(IDataGridLayout dataGridLayout)
		{
			if (!string.IsNullOrWhiteSpace(Settings.TablesLayoutInformation))
			{
				var layout = Settings.TablesLayoutInformation;
				dataGridLayout.LoadLayout(layout);
			}
		}
	}
}
