using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Jeeves table
	/// </summary>
	[DataContract]
	public class Table : DocModelBase
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[DataMember(Order = 2)]
		public string Id { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 3)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		[DataMember(Order = 4)]
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the records.
		/// </summary>
		[DataMember(Order = 5)]
		public Records Records { get; set; }

		/// <summary>
		/// Gets or sets the programs.
		/// </summary>
		[DataMember(Order = 6)]
		public Programs Programs { get; set; }

		/// <summary>
		/// Gets or sets the fields.
		/// </summary>
		[DataMember(Order = 7)]
		public Fields Fields { get; set; }
	}
}
