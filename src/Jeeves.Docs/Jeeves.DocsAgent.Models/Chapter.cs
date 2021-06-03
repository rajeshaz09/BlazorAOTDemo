using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Chapter in documentation
	/// </summary>
	[DataContract]
	public class Chapter : DocModelBase
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[DataMember(Order = 2)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 3)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the revision.
		/// </summary>
		[DataMember(Order = 4)]
		public string Revision { get; set; }

		/// <summary>
		/// Gets or sets the documentation.
		/// </summary>
		[DataMember(Order = 5)]
		public string Documentation { get; set; }

		/// <summary>
		/// Gets or sets the sections.
		/// </summary>
		[DataMember(Order = 6)]
		public Sections Sections { get; set; } = new Sections();

		/// <summary>
		/// Gets or sets the chapter images.
		/// </summary>
		[DataMember(Order = 7)]
		public List<Image> ChapterImages { get; set; } = new List<Image>();
	}
}
