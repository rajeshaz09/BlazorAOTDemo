using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Collection of versions.
	/// </summary>
	[DataContract]
	public class Versions
	{
		/// <summary>
		/// Gets or sets the version collection.
		/// </summary>
		[DataMember(Order = 0)]
		public List<Version> VersionCollection { get; set; } = new List<Version>();
	}
}
