using System.Runtime.Serialization;

namespace Jeeves.DocsAgent.Models
{
	/// <summary>
	/// Contains information about the image.
	/// </summary>
	[DataContract]
	public class Image
	{
		/// <summary>
		/// Gets or sets the image.
		/// </summary>
		[DataMember(Order = 0)]
		public string ImageName { get; set; }

		/// <summary>
		/// Gets or sets the image path.
		/// </summary>
		[DataMember(Order = 1)]
		public string ImagePath { get; set; }
	}
}
