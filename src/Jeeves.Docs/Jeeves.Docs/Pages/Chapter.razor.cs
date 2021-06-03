using Jeeves.Docs.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Jeeves.Docs.Pages
{
	/// <summary>
	/// Chapter component.
	/// </summary>
	/// <seealso cref="ComponentBase" />
	public partial class Chapter
	{
		/// <summary>
		/// Gets or sets the chapter identifier.
		/// </summary>
		[Parameter]
		public string ChapterId { get; set; }

		/// <summary>
		/// Gets or sets the chapter.
		/// </summary>
		public DocsAgent.Models.Chapter ChapterContents { get; set; }

		/// <summary>
		/// Gets or sets the settings.
		/// </summary>
		[Inject]
		public Settings Settings { get; set; }

		/// <summary>
		/// Gets or sets the navigation manager.
		/// </summary>
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		/// <summary>
		/// Gets or sets the data service.
		/// </summary>
		[Inject]
		public IDataService DataService { get; set; }

		/// <summary>
		/// Gets or sets the java script.
		/// </summary>
		[Inject]
		public IJavaScript JavaScript { get; set; }

		/// <summary>
		/// Gets or sets the locale static texts.
		/// </summary>
		[Inject]
	  public LocaleStaticTexts LocaleStaticTexts { get; set; }

		/// <summary>
		/// Selects the node.
		/// </summary>
		/// <param name="text">The text.</param>
		void SelectNode(string text)
		{
			if (Settings.TreeView != null)
				Settings.TreeView.SelectNode((n) => n.Text == text);
		}

		/// <summary>
		/// Method invoked when the component is ready to start, having received its
		/// initial parameters from its parent in the render tree.
		/// Override this method if you will perform an asynchronous operation and
		/// want the component to refresh when that operation is completed.
		/// </summary>
		protected override async Task OnInitializedAsync()
		{
			if(Settings.Breadcrumbs.Count == 0)
			{
			  await	Task.Delay(1000);
			}
			await base.OnInitializedAsync();
		}

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			ChapterContents = await DataService.GetChapter(ChapterId);
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
			ScrollToTop();
			await ScrollToFragment();
		}

		/// <summary>
		/// Scrolls to fragment.
		/// </summary>
		private async Task ScrollToFragment()
		{
			var uri = new Uri(NavigationManager.Uri, UriKind.Absolute);
			var fragment = uri.Fragment;
			if (fragment.StartsWith('#'))
			{
				var elementId = fragment.Substring(1);
				if (!string.IsNullOrEmpty(elementId))
				{
					await JavaScript.InvokeVoidAsync("BlazorJavaScriptSupport.NavigateToHtmlElement", elementId);
				}
			}
		}

		/// <summary>
		/// Scrolls to top of the page.
		/// </summary>
		private async void ScrollToTop()
		{
			await JavaScript.InvokeVoidAsync("BlazorJavaScriptSupport.ScrollToTop", "documentContainer");
		}

		/// <summary>
		/// Navigates to HTML element.
		/// </summary>
		/// <param name="identifier">The identifier.</param>
		private async void NavigateToHtmlElement(string identifier)
		{
			await JavaScript.InvokeVoidAsync("BlazorJavaScriptSupport.NavigateToHtmlElement", identifier);
		}
	}
}
