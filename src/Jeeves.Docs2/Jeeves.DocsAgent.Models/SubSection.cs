using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Contains information about subsection.
	/// </summary>
	[DataContract]
	public class SubSection
	{
		/// <summary>
		/// Gets or sets the serial no.
		/// </summary>
		[DataMember(Order = 0)]
		public string SerialNo { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[DataMember(Order = 1)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the sub identifier.
		/// </summary>
		[DataMember(Order = 2)]
		public string SubId { get; set; }

		/// <summary>
		/// Gets or sets the name of the sub.
		/// </summary>
		[DataMember(Order = 3)]
		public string SubName { get; set; }

		/// <summary>
		/// Gets or sets the type of the sub.
		/// </summary>
		[DataMember(Order = 4)]
		public string SubType { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 5)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 6)]
		public string SubDescription { get; set; }

		/// <summary>
		/// Gets or sets the records.
		/// </summary>
		[DataMember(Order = 7)]
		public Records Records { get; set; }

		/// <summary>
		/// Gets or sets the sub section images.
		/// </summary>
		[DataMember(Order = 8)]
		public List<Image> SubSectionImages { get; set; } = new List<Image>();
	}
}
