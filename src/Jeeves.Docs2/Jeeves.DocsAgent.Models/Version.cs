using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Information about version.
	/// </summary>
	[DataContract]
	public class Version
	{
		/// <summary>
		/// Gets or sets the version number.
		/// </summary>
		[DataMember(Order = 0)]
		public string VersionNumber { get; set; }

		/// <summary>
		/// Gets or sets the version description.
		/// </summary>
		[DataMember(Order = 1)]
		public string VersionDescription { get; set; }
	}
}
