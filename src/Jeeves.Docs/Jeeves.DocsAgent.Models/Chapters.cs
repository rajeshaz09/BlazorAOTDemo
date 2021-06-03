using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Chapters information.
	/// </summary>
	[DataContract]
	public class Chapters : DocModelBase
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 2)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the chapter collection.
		/// </summary>
		[DataMember(Order = 3)]
		public List<Chapter> ChapterCollection { get; set; } = new List<Chapter>();
	}
}
