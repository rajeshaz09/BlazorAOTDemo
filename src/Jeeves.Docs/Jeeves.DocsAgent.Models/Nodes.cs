using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Nodes information.
	/// </summary>
	[DataContract]
	public class Nodes
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 0)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the node collection.
		/// </summary>
		[DataMember(Order = 1)]
		public List<Node> NodeCollection { get; set; } = new List<Node>();
	}
}
