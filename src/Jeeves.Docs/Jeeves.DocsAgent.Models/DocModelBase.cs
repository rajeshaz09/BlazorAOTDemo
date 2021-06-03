using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Document settings
	/// </summary>
	[DataContract]
	public class DocModelBase
	{
		/// <summary>
		/// Gets or sets the version.
		/// </summary>
		[DataMember(Order = 0)]
		public string Version { get; set; }

		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		[DataMember(Order = 1)]
		public string Language { get; set; }
	}
}
