using Jeeves.Docs.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Jeeves.Docs.Pages
{
	/// <summary>
	/// Index component
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
	public partial class Index
	{
		/// <summary>
		/// Gets or sets the home page static texts.
		/// </summary>
		[Inject]
		public HomePageStaticTexts HomePageStaticTexts { get; set; }

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			// The reason behind using delay is that there has been a known bug in the blazor life cycle events. That is the life cycle events of pages
			// are not running sequentially when we do any task operation in one of the pages which results the inconsistent pattern. So bug has been 
			// logged to the microsoft and we have to modify this once we get the proper solution.
			while (HomePageStaticTexts.SubTitleOne == null && HomePageStaticTexts.SubTitleTwo == null && HomePageStaticTexts.Title == null)
			{
				await Task.Delay(100);
			}
			await base.OnParametersSetAsync();
		}
	}
}
