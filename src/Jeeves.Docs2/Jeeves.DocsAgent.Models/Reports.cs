using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Reports information.
	/// </summary>
	[DataContract]
	public class Reports
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 0)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the report collection.
		/// </summary>
		[DataMember(Order = 1)]
		public List<Report> ReportCollection { get; set; } = new List<Report>();
	}
}
