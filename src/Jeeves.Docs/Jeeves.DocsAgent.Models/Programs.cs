using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Jeeves programs.
	/// </summary>
	[DataContract]
	public class Programs : DocModelBase
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 2)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the content
		/// </summary>
		[DataMember(Order = 3)]
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the program collection.
		/// </summary>
		[DataMember(Order = 4)]
		public List<Program> ProgramCollection { get; set; } = new List<Program>();
	}
}
