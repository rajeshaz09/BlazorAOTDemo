using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Report information.
	/// </summary>
	[DataContract]
	public class Report
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

		/// <summary>
		/// Gets or sets the sub description.
		/// </summary>
		[DataMember(Order = 2)]
		public string SubDescription { get; set; }
	}
}
