using System.Threading.Tasks;

namespace Jeeves.Docs2.Models
{
	/// <summary>
	/// Native javascript interface.
	/// </summary>
	public interface IJavaScript
	{
		/// <summary>
		/// Calls the javascript functions with the passed method name and parameters asynchronously.
		/// </summary>
		/// <param name="methodName">Name of the method to invoke.</param>
		/// <param name="parameter">The parameter to be passed.</param>
		Task InvokeVoidAsync(string methodName, string parameter);
	}
}
