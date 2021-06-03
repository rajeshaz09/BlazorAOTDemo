using Jeeves.Docs.Models;
using Microsoft.JSInterop;
using System;
using System.Text.Json;

namespace Jeeves.Docs.Services
{
	/// <summary>
	/// API to access local storage
	/// </summary>
	/// <seealso cref="Jeeves.Docs.Models.ILocalStorage" />
	public class LocalStorageService : ILocalStorage
	{
		private readonly IJSInProcessRuntime _jSInProcessRuntime;

		/// <summary>
		/// Initializes a new instance of the <see cref="LocalStorageService"/> class.
		/// </summary>
		/// <param name="jSRuntime">The j s runtime.</param>
		public LocalStorageService(IJSRuntime jSRuntime)
		{
			_jSInProcessRuntime = jSRuntime as IJSInProcessRuntime;
		}

		/// <summary>
		/// Sets or updates the <paramref name="data" /> in local storage with the specified <paramref name="key" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key">A <see cref="string" /> value specifying the name of the storage slot to use</param>
		/// <param name="data">The data to be saved</param>
		/// <exception cref="ArgumentNullException">key</exception>
		/// <exception cref="InvalidOperationException">IJSInProcessRuntime not available</exception>
		public void SetItem<T>(string key, T data)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException(nameof(key));

			if (_jSInProcessRuntime == null)
				throw new InvalidOperationException("IJSInProcessRuntime not available");

			_jSInProcessRuntime.InvokeVoid("localStorage.setItem", key, JsonSerializer.Serialize(data));
		}

		/// <summary>
		/// Retrieve the specified data from local storage as a <typeparamref name="T" />.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key">A <see cref="string" /> value specifying the name of the local storage slot to use</param>
		/// <returns>
		/// The data from the specified <paramref name="key" /> as a <typeparamref name="T" />
		/// </returns>
		/// <exception cref="ArgumentNullException">key</exception>
		/// <exception cref="InvalidOperationException">IJSInProcessRuntime not available</exception>
		public T GetItem<T>(string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException(nameof(key));

			if (_jSInProcessRuntime == null)
				throw new InvalidOperationException("IJSInProcessRuntime not available");

			var serialisedData = _jSInProcessRuntime.Invoke<string>("localStorage.getItem", key);

			if (string.IsNullOrWhiteSpace(serialisedData))
				return default;
		  return JsonSerializer.Deserialize<T>(serialisedData);

		}

		/// <summary>
		/// Remove the data with the specified <paramref name="key" />.
		/// </summary>
		/// <param name="key">A <see cref="string" /> value specifying the name of the storage slot to use</param>
		/// <exception cref="ArgumentNullException">key</exception>
		/// <exception cref="InvalidOperationException">IJSInProcessRuntime not available</exception>
		public void RemoveItem(string key)
		{
			if (string.IsNullOrEmpty(key))
				throw new ArgumentNullException(nameof(key));

			if (_jSInProcessRuntime == null)
				throw new InvalidOperationException("IJSInProcessRuntime not available");

			_jSInProcessRuntime.InvokeVoid("localStorage.removeItem", key);
		}

		/// <summary>
		/// Clears all data from local storage.
		/// </summary>
		/// <exception cref="InvalidOperationException">IJSInProcessRuntime not available</exception>
		public void Clear()
		{
			if (_jSInProcessRuntime == null)
				throw new InvalidOperationException("IJSInProcessRuntime not available");

			_jSInProcessRuntime.InvokeVoid("localStorage.clear");
		}

		/// <summary>
		/// Checks if the <paramref name="key" /> exists in local storage, but does not check its value.
		/// </summary>
		/// <param name="key">A <see cref="string" /> value specifying the name of the storage slot to use</param>
		/// <returns>
		/// Boolean indicating if the specified <paramref name="key" /> exists
		/// </returns>
		/// <exception cref="InvalidOperationException">IJSInProcessRuntime not available</exception>
		public bool ContainKey(string key)
		{
			if (_jSInProcessRuntime == null)
				throw new InvalidOperationException("IJSInProcessRuntime not available");

			return _jSInProcessRuntime.Invoke<bool>("localStorage.hasOwnProperty", key);
		}
	}
}
