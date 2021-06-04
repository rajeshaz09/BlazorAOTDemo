using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Table of contents.
	/// </summary>
	/// <seealso cref="DocModelBase" />
	[DataContract]
	public class TableOfContents : DocModelBase
	{
		/// <summary>
		/// Gets or sets the document items.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
		[DataMember(Order = 2)]
		public List<DocItem> DocItems { get; set; } = new List<DocItem>();
	}
}
