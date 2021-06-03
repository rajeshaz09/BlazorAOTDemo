using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Jeeves program
	/// </summary>
	[DataContract]
	public class Program : DocModelBase
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
		/// Gets or sets the area.
		/// </summary>
		[DataMember(Order = 4)]
		public string Area { get; set; }

		/// <summary>
		/// Gets or sets the content.
		/// </summary>
		[DataMember(Order = 5)]
		public string Content { get; set; }

		/// <summary>
		/// Gets or sets the chapters.
		/// </summary>
		[DataMember(Order = 6)]
		public Chapters Chapters { get; set; }

		/// <summary>
		/// Gets or sets the records.
		/// </summary>
		[DataMember(Order = 7)]
		public Records Records { get; set; }

		/// <summary>
		/// Gets or sets the tables.
		/// </summary>
		[DataMember(Order = 8)]
		public Tables Tables { get; set; }

		/// <summary>
		/// Gets or sets the reports.
		/// </summary>
		[DataMember(Order = 9)]
		public Reports Reports { get; set; }

		/// <summary>
		/// Gets or sets the nodes.
		/// </summary>
		[DataMember(Order = 10)]
		public Nodes Nodes { get; set; }
	}
}
