using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Jeeves field
	/// </summary>
	[DataContract]
	public class Field : DocModelBase
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
		/// Gets or sets the column header.
		/// </summary>
		[DataMember(Order = 4)]
		public string ColumnHeader { get; set; }

		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		[DataMember(Order = 5)]
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the type of the jeeves data.
		/// </summary>
		[DataMember(Order = 6)]
		public string JeevesDataType { get; set; }

		/// <summary>
		/// Gets or sets the size.
		/// </summary>
		[DataMember(Order = 7)]
		public string Size { get; set; }

		/// <summary>
		/// Gets or sets the precision.
		/// </summary>
		[DataMember(Order = 8)]
		public string Precision { get; set; }

		/// <summary>
		/// Gets or sets the type of the SQL data.
		/// </summary>
		[DataMember(Order = 9)]
		public string SQLDataType { get; set; }

		/// <summary>
		/// Gets or sets the records.
		/// </summary>
		[DataMember(Order = 10)]
		public Records Records { get; set; }

		/// <summary>
		/// Gets or sets the tables.
		/// </summary>
		[DataMember(Order = 11)]
		public Tables Tables { get; set; }
	}
}
