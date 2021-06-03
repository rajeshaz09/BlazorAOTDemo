using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Node information
	/// </summary>
	[DataContract]
	public class   Node
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
	}
}
