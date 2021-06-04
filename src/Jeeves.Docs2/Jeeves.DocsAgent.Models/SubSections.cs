using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Contains information about the subsections.
	/// </summary>
	[DataContract]
	public class SubSections
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 0)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the sub section collection.
		/// </summary>
		[DataMember(Order = 1)]
		public List<SubSection> SubSectionCollection { get; set; } = new List<SubSection>();
	}
}
