using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Contains information about the section.
	/// </summary>
	/// <seealso cref="Jeeves.DocsAgent.Models.DocModelBase" />
	[DataContract]
	public class Section
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[DataMember(Order = 0)]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the serial no.
		/// </summary>
		[DataMember(Order = 1)]
		public string SerialNo { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 2)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the section images.
		/// </summary>
		[DataMember(Order = 3)]
		public List<Image> SectionImages { get; set; } = new List<Image>();

		/// <summary>
		/// Gets or sets the sub sections.
		/// </summary>
		[DataMember(Order = 4)]
		public SubSections SubSections { get; set; } = new SubSections();
	}
}
