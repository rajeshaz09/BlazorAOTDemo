using DevExpress.Blazor;
using Jeeves.Docs.Models;
using Jeeves.DocsAgent.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jeeves.Docs.Shared
{
	/// <summary>
	/// Nav menu for left side bar navigation.
	/// </summary>
	/// <seealso cref="ComponentBase" />
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
	public partial class NavMenu
	{
		private const int MinimumFilterLength = 2;

		#region Private Fields
		private List<DocItem> _navigationItems = new List<DocItem>();
		private string _filterText;
		private bool _showToc;
		#endregion

		/// <summary>
		/// Gets or sets the document items.
		/// </summary>
		[Parameter]
		public TableOfContents Toc { get; set; }

		/// <summary>
		/// Gets or sets the filtered search items.
		/// </summary>
		public List<DocItem> FilteredItems { get; set; } = new List<DocItem>();

		/// <summary>
		/// Gets or sets the breadcrumbs.
		/// </summary>
		List<ITreeViewNodeInfo> Breadcrumbs { get; } = new List<ITreeViewNodeInfo>();

		/// <summary>
		/// Gets or sets the TreeView.
		/// </summary>
		DxTreeView TreeView { get; set; }

		/// <summary>
		/// Gets or sets the settings.
		/// </summary>
		[Inject]
		Settings Settings { get; set; }

		/// <summary>
		/// Gets or sets the filter text.
		/// </summary>
		public string FilterText
		{
			get => _filterText;
			set
			{
				FilterTOC(_filterText, value);
				_filterText = value;
			}
		}

		/// <summary>
		/// Gets or sets the navigation manager.
		/// </summary>
		[Inject]
		NavigationManager NavigationManager { get; set; }

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
		/// Gets or sets the program document items.
		/// </summary>
		public List<DocItem> ProgramDocItems { get;} = new List<DocItem>();

		/// <summary>
		/// Gets the field document items.
		/// </summary>
		public List<DocItem> FieldDocItems { get; } = new List<DocItem>();

		/// <summary>
		/// Gets the table document items.
		/// </summary>
		public List<DocItem> TableDocItems { get; } = new List<DocItem>();

		/// <summary>
		/// Gets or sets a value indicating whether need synchronization or not.
		/// </summary>
		private bool NeedSync { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the result is found or not.
		/// </summary>
		private bool ResultFound { get; set; }

		/// <summary>
		/// Gets or sets the selected document item.
		/// </summary>
		private DocItem CurrentDocItem { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is tree expanded and collapsed.
		/// </summary>
		private bool IsTreeExpandedAndCollapsed { get; set; }


		/// <summary>
		/// Method invoked when the component is ready to start, having received its
		/// initial parameters from its parent in the render tree.
		/// Override this method if you will perform an asynchronous operation and
		/// want the component to refresh when that operation is completed.
		/// </summary>
		protected override async Task OnInitializedAsync()
		{
			var programs = DataService.GetPrograms();
			var fields = DataService.GetFields();
			var tables = DataService.GetTables();
			await Task.WhenAll(programs, fields, tables);
			SetProgramDocItems(programs);
			SetFieldDocItems(fields);
			SetTableDocItems(tables);
			await base.OnInitializedAsync();
		}

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			if (string.IsNullOrWhiteSpace(FilterText))
			{
				_showToc = true;
				_navigationItems = GetNavigationItems(Toc?.DocItems);
				_navigationItems.AddRange(ProgramDocItems);
				_navigationItems.AddRange(FieldDocItems);
				_navigationItems.AddRange(TableDocItems);
			}
			await base.OnParametersSetAsync();
		}

		/// <summary>
		/// Method invoked after each time the component has been rendered. Note that the component does
		/// not automatically re-render after the completion of any returned <see cref="T:System.Threading.Tasks.Task" />, because
		/// that would cause an infinite render loop.
		/// </summary>
		/// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
		/// on this component instance; otherwise <c>false</c>.</param>
		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (NavigationManager.Uri != NavigationManager.BaseUri)
			{
				string currentRoute = NavigationManager.Uri.Remove(0, NavigationManager.BaseUri.Count());
				string[] routePaths = currentRoute.Split('/');
				while (Toc?.DocItems == null)
				{
					await Task.Delay(100);
				}
				ProcessReferenceGuide(routePaths);
				if (!ResultFound)
				{
					var docItemType = char.ToUpper(routePaths[0][0]) + routePaths[0].Substring(1).ToLower();
					try
					{
						CurrentDocItem = new DocItem() { DocItemType = (DocItemType)Enum.Parse(typeof(DocItemType), docItemType), Id = routePaths[1] };
						TransverseDocItems();
						if(ResultFound)
						  NeedSync = true;
					}
					catch (Exception)
					{
						return;
					}
				}
			}
			await base.OnAfterRenderAsync(firstRender);
		}

		/// <summary>
		/// Processes the reference guide.
		/// </summary>
		/// <param name="parts">The parts of the current URL</param>
		private void ProcessReferenceGuide(string[] parts)
		{
			if (parts.Count() == 1)
			{
				switch (parts[0].ToLower())
				{
					case "programs":
					case "fields":
					case "tables":
						TreeView.SetNodeExpanded(n => n.Text == Toc?.DocItems?.LastOrDefault()?.Description, true);
						TreeView.SetNodeExpanded(n => n.Text == parts[0], true);
						ResultFound = true;
						break;
				}
			}
		}

		/// <summary>
		/// Transverses the document items.
		/// </summary>
		private void TransverseDocItems()
		{
			foreach (var docItem in Toc?.DocItems)
			{
				SetSelectedMenuItems(docItem);
			}
		}

		/// <summary>
		/// Returns a flag to indicate whether the component should render.
		/// </summary>
		/// <returns>The value of true or false.</returns>
		protected override bool ShouldRender()
		{
			bool shouldRender = NeedSync || base.ShouldRender();
			NeedSync = false;
			return shouldRender;
		}

		/// <summary>
		/// Sets the selected menu items.
		/// </summary>
		/// <param name="docItem">The document item.</param>
		private void SetSelectedMenuItems(DocItem docItem)
		{
			for (int i = 0; i < docItem.DocItems.Count; i++)
			{
				var currentDocItem = docItem.DocItems[i];
				if (currentDocItem.DocItemType != DocItemType.Chapter)
				{
					if (ResultFound == true)
						return;
					else
						SetSelectedMenuItems(currentDocItem);
				}
				else
				{
					if (currentDocItem.Id.ToLower() == CurrentDocItem.Id.ToLower())
					{
						ResultFound = true;
						SelectNode(currentDocItem);
						return;
					}
				}
			}
		}

		/// <summary>
		/// Selects the node.
		/// </summary>
		/// <param name="currentDocItem">The current document item.</param>
		private void SelectNode(DocItem currentDocItem)
		{
			ExpandTreeView();
			TreeView.SelectNode(node => ((DocItem)node.DataItem).Id == currentDocItem.Id);
			CollpaseTreeView();
			TransverseTreeView();
		}

		/// <summary>
		/// Transverses the TreeView.
		/// </summary>
		private void TransverseTreeView()
		{
			if (TreeView.GetSelectedNodeInfo().Parent.Level != 0)
			{
				IsTreeExpandedAndCollapsed = true;
				SelectNode((DocItem)TreeView.GetSelectedNodeInfo().Parent.DataItem);
			}
		}

		/// <summary>
		/// Collpases the TreeView.
		/// </summary>
		private void CollpaseTreeView()
		{
			if (!IsTreeExpandedAndCollapsed)
			{
				TreeView.CollapseAll();
			}
		}

		/// <summary>
		/// Expands the TreeView.
		/// </summary>
		private void ExpandTreeView()
		{
			if (!IsTreeExpandedAndCollapsed)
			{
				TreeView.ExpandAll();
			}
		}


		/// <summary>
		/// Gets the navigation items.
		/// </summary>
		/// <param name="docItems">The document items.</param>
		/// <returns>The list of doc items.</returns>
		private List<DocItem> GetNavigationItems(List<DocItem> docItems)
		{
			var filteredList = new List<DocItem>();
			if (docItems != null)
				foreach (var item in docItems)
				{
					if (item.DocItemType == DocItemType.DocLevel)
					{
						if (item.DocItems.Count > 0)
							filteredList.AddRange(GetNavigationItems(item.DocItems));
					}
					else
					{
						filteredList.Add(item);
					}
				}
			return filteredList;
		}

		/// <summary>
		/// Performs the filter operation on the table of contents.
		/// </summary>
		/// <param name="oldFilter">The old filter.</param>
		/// <param name="filter">The filter.</param>
		private void FilterTOC(string oldFilter, string filter)
		{
			_showToc = string.IsNullOrWhiteSpace(filter) || filter.Length < MinimumFilterLength;
			if (_showToc)
			{
				FilteredItems = _navigationItems;
			}
			else
			{
				if (oldFilter != null && filter.Length > MinimumFilterLength && filter.StartsWith(oldFilter, StringComparison.OrdinalIgnoreCase))
					FilteredItems = FilteredItems.Where(item => item.Description.Contains(filter, StringComparison.OrdinalIgnoreCase))
					.ToList();

				FilteredItems = _navigationItems.Where(item => item.Description.Contains(filter, StringComparison.OrdinalIgnoreCase))
						.ToList();
			}
		}

		/// <summary>
		/// Gets the routing path.
		/// </summary>
		/// <param name="dataItem">The data item.</param>
		/// <returns>Returns the navigation URL.</returns>
		private static string GetRoutingPath(DocItem dataItem)
		{
			if (dataItem.DocItemType == DocItemType.DocLevel)
			{
				switch (dataItem.Id)
				{
					case "Programs":
					case "Fields":
					case "Tables":
						return dataItem.Id;
					default:
						break;
				}
				return null;
			}
			else
			{
				return (string.Concat(dataItem.DocItemType, "/", dataItem.Id));
			}
		}

		/// <summary>
		/// Selections the changed.
		/// </summary>
		/// <param name="e">The <see cref="TreeViewNodeEventArgs"/> instance containing the event data.</param>
		private void SelectionChanged(TreeViewNodeEventArgs e)
		{
			SetBreadCrumbs(e.NodeInfo);
		}

		/// <summary>
		/// Sets the bread crumbs.
		/// </summary>
		/// <param name="currentNodeInfo">The current node information.</param>
		private void SetBreadCrumbs(ITreeViewNodeInfo currentNodeInfo)
		{
			Breadcrumbs.Clear();
			do
			{
				Breadcrumbs.Add(currentNodeInfo);
				currentNodeInfo = currentNodeInfo.Parent;
			}
			while (currentNodeInfo != null);
			Breadcrumbs.RemoveAt(0);
			Settings.Breadcrumbs = Breadcrumbs;
			Settings.TreeView = TreeView;
			Settings.IsMenuItemClicked = true;
		}

		/// <summary>
		/// Gets the navigation URL.
		/// </summary>
		/// <param name="dataItem">The data item.</param>
		/// <returns>Returns the navigation url.</returns>
		private string GetNavigationUrl(DocItem dataItem)
		{
			if (dataItem.DocItemType == DocItemType.DocLevel)
				return NavigationManager.Uri;

			return $"{dataItem.DocItemType}/{dataItem.Id}";
		}


		/// <summary>
		/// Sets the table document items.
		/// </summary>
		/// <param name="tables">Tables task collection.</param>
		private void SetTableDocItems(Task<Tables> tables)
		{
			var tableDocItems = tables?.Result?.TableCollection ?? new List<Table>();
			foreach (var t in tableDocItems)
			{
				TableDocItems.Add(new DocItem()
				{
					Id = t.Id,
					DocItemType = DocItemType.Table,
					Description = t.Description
				});
			}
		}
		/// <summary>
		/// Sets the field document items.
		/// </summary>
		/// <param name="fields">Fields task collection.</param>
		private void SetFieldDocItems(Task<Fields> fields)
		{
			var fieldDocItems = fields?.Result?.FieldCollection ?? new List<Field>();
			foreach (var f in fieldDocItems)
			{
				FieldDocItems.Add(new DocItem()
				{
					Id = f.Id,
					DocItemType = DocItemType.Field,
					Description = f.Description
				});
			}
		}

		/// <summary>
		/// Sets the program document items.
		/// </summary>
		/// <param name="programs">Programs task collection.</param>
		private void SetProgramDocItems(Task<Programs> programs)
		{
			var programsDocItems = programs?.Result?.ProgramCollection ?? new List<DocsAgent.Models.Program>();
			foreach (var p in programsDocItems)
			{
				ProgramDocItems.Add(new DocItem()
				{
					Id = p.Id,
					DocItemType = DocItemType.Program,
					Description = p.Description
				});
			}
		}
	}
}
