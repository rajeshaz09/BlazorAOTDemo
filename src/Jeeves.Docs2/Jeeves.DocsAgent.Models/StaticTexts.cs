using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Holds the collection of static texts.
	/// </summary>
	[DataContract]
	public class StaticTexts : DocModelBase
	{
		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		[DataMember(Order = 2)]
		public List<Item> Items { get; set; } = new List<Item>();
	}
}
