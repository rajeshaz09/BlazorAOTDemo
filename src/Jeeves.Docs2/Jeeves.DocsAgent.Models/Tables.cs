using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Jeeves tables
	/// </summary>
	[DataContract]
	public class Tables : DocModelBase
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 2)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the List of table items.
		/// </summary>
		[DataMember(Order = 3)]
		public List<Table> TableCollection { get; set; } = new List<Table>();
	}
}
