namespace Jeeves.Docs.Models
{
	/// <summary>
	/// Local storage access api
	/// </summary>
	public interface ILocalStorage
	{
		/// <summary>
		/// Clears all data from local storage.
		/// </summary>
		void Clear();

		/// <summary>
		/// Retrieve the specified data from local storage as a <typeparamref name="T"/>.
		/// </summary>
		/// <param name="key">A <see cref="string"/> value specifying the name of the local storage slot to use</param>
		/// <returns>The data from the specified <paramref name="key"/> as a <typeparamref name="T"/></returns>
		T GetItem<T>(string key);

		/// <summary>
		/// Checks if the <paramref name="key"/> exists in local storage, but does not check its value.
		/// </summary>
		/// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
		/// <returns>Boolean indicating if the specified <paramref name="key"/> exists</returns>
		bool ContainKey(string key);

		/// <summary>
		/// Remove the data with the specified <paramref name="key"/>.
		/// </summary>
		/// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
		void RemoveItem(string key);

		/// <summary>
		/// Sets or updates the <paramref name="data"/> in local storage with the specified <paramref name="key"/>.
		/// </summary>
		/// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
		/// <param name="data">The data to be saved</param>
		void SetItem<T>(string key, T data);
	}
}
