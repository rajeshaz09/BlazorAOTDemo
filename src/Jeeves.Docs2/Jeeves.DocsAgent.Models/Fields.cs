using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Fields information.
	/// </summary>
	[DataContract]
	public class Fields : DocModelBase
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[DataMember(Order = 2)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the columns.
		/// </summary>
		[DataMember(Order = 3)]
		public List<string> Columns { get; set; } = new List<string>();

		/// <summary>
		/// Gets or sets the field collection.
		/// </summary>
		[DataMember(Order = 4)]
		public List<Field> FieldCollection { get; set; } = new List<Field>();
	}
}
