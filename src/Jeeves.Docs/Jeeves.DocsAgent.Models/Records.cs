using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Jeeves records
	/// </summary>
	[DataContract]
	public class Records
	{
		/// <summary>
		/// Term key.
		/// </summary>
		[DataMember(Order = 0)]
	  public string TermKey { get; set; }

		/// <summary>
		/// Term key prompt.
		/// </summary>
		[DataMember(Order = 1)]
		public string TermKeyPrompt { get; set; }

		/// <summary>
		/// Term description.
		/// </summary>
		[DataMember(Order = 2)]
		public string TermDesc { get; set; }

		/// <summary>
		/// Term description prompt.
		/// </summary>
		[DataMember(Order = 3)]
		public string TermDescPrompt { get; set; }

		/// <summary>
		/// Gets or sets the record items.
		/// </summary>
		[DataMember(Order = 4)]
		public List<Record> RecordCollection { get; set; } = new List<Record>();
	}
}
