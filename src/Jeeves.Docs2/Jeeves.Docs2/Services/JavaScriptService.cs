using Jeeves.Docs2.Models;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Jeeves.Docs2.Services
{
	/// <summary>
	/// Javascript service.
	/// </summary>
	public class JavaScriptService : IJavaScript
	{
		#region Private fields
		private readonly IJSInProcessRuntime _jSInProcessRuntime;
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="LocalStorageService"/> class.
		/// </summary>
		/// <param name="jSRuntime">The js runtime.</param>
		public JavaScriptService(IJSRuntime jSRuntime)
		{
			_jSInProcessRuntime = jSRuntime as IJSInProcessRuntime;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Calls the javascript functions with the passed method name and parameters asynchronously.
		/// </summary>
		/// <param name="methodName">Name of the method to invoke.</param>
		/// <param name="parameter">The parameter to be passed.</param>
		public async Task InvokeVoidAsync(string methodName, string parameter)
		{
			if (_jSInProcessRuntime == null)
				throw new InvalidOperationException("IJSInProcessRuntime not available");
			await _jSInProcessRuntime.InvokeVoidAsync(methodName, parameter);
		}
		#endregion
	}
}
