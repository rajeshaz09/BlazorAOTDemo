using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Details of the document.
	/// </summary>
	[DataContract]
	public class Item
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[DataMember(Order = 0)]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[JsonPropertyName("Desc")]
		[DataMember(Order = 1)]
		public string Description { get; set; }
	}
}
