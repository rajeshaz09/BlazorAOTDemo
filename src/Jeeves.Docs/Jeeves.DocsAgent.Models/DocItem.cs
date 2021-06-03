using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Collection of documents.
	/// </summary>
	[DataContract]
	public class DocItem
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[DataMember(Order = 0)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 1)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the type of the item.
		/// </summary>
		[DataMember(Order = 2)]
		public DocItemType DocItemType { get; set; }

		/// <summary>
		/// Gets or sets the document items.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
		[DataMember(Order = 3)]
		public List<DocItem> DocItems { get; set; } = new List<DocItem>();

	}
}
