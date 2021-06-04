using System.Collections.Generic;

namespace Jeeves.Docs2.Models
{
    /// <summary>
    /// Global settings of the app
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
	public class Settings
	{
		/// <summary>
		/// Gets or sets the version.
		/// </summary>
		public string Version { get; set; } = "0";

		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		public string Language { get; set; } = "999";

		/// <summary>
		/// Gets or sets the error.
		/// </summary>
		public string Error { get; set; }

		/// <summary>
		/// Gets or sets the programs layout information.
		/// </summary>
		public string ProgramsLayoutInformation { get; set; }

		/// <summary>
		/// Gets or sets the tables layout information.
		/// </summary>
		public string TablesLayoutInformation { get; set; }

		/// <summary>
		/// Gets or sets the fields layout information.
		/// </summary>
		public string FieldsLayoutInformation { get; set; }

		/// <summary>
		/// Gets or sets the breadcrumbs.
		/// </summary>
		//public List<ITreeViewNodeInfo> Breadcrumbs { get; set; } = new List<ITreeViewNodeInfo>();

		/// <summary>
		/// Gets or sets the TreeView.
		/// </summary>
		//public DxTreeView TreeView { get; set; }

		/// <summary>
		/// Gets or sets the is menu item clicked.
		/// </summary>
		public bool IsMenuItemClicked { get; set; }
	}
}
