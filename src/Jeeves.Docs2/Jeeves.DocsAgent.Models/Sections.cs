using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Contains information about sections.
	/// </summary>
	/// <seealso cref="Jeeves.DocsAgent.Models.DocModelBase" />
	[DataContract]
	public class Sections
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 0)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the sections.
		/// </summary>
		[DataMember(Order = 1)]
		public List<Section> SectionCollection { get; set; } = new List<Section>();
	}
}
