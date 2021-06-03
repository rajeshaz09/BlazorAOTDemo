using DevExpress.Blazor;
using Jeeves.Docs.Extensions;
using Jeeves.Docs.Models;
using Jeeves.DocsAgent.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords")]
namespace Jeeves.Docs.Shared
{
	/// <summary>
	/// Main layout.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Components.LayoutComponentBase" />
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "<Pending>")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0005:Component parameter should not be set outside of its component.", Justification = "<Pending>")]
	public partial class MainLayout
	{
		#region Private Constants
		private const string English = "999";
		private const string Swedish = "0";
		private const string ISOEnglishCode = "en";
		private const string ISOSwedishCode = "sv";
		private const string VersionKey = "version";
		private const string LanguageKey = "language";
		#endregion

		/// <summary>
		/// Gets or sets the home page static texts.
		/// </summary>
		[Inject]
		public HomePageStaticTexts HomePageStaticTexts { get; set; }

		/// <summary>
		/// Gets or sets the locale static texts.
		/// </summary>
		[Inject]
		public LocaleStaticTexts LocaleStaticTexts { get; set; }

		/// <summary>
		/// Gets or sets the default settings.
		/// </summary>
		[Inject]
		public Settings Default { get; set; }

		/// <summary>
		/// Gets or sets the data service.
		/// </summary>
		[Inject]
		public IDataService DataService { get; set; }

		/// <summary>
		/// Gets or sets the navigation manager.
		/// </summary>
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		/// <summary>
		/// Gets or sets the settings.
		/// </summary>
		[Inject]
		public Settings Settings { get; set; }

		/// <summary>
		/// Gets or sets the language menu item.
		/// </summary>
		public DxMenuItem LanguageMenuItem { get; set; }

		/// <summary>
		/// Gets or sets the version menu item.
		/// </summary>
		public DxMenuItem VersionMenuItem { get; set; }

		/// <summary>
		/// Gets or sets the document items.
		/// </summary>
		public TableOfContents Toc { get; private set; }

		/// <summary>
		/// Gets or sets the versions.
		/// </summary>
		public Versions Versions { get; set; } = new Versions();

		/// <summary>
		/// Gets or sets the languages.
		/// </summary>
		public IList<string> Languages { get; set;} = new List<string>();

		/// <summary>
		/// Gets or sets the local storage.
		/// </summary>
		[Inject]
		public ILocalStorage LocalStorage { get; set; }

		/// <summary>
		/// Method invoked when the component has received parameters from its parent in
		/// the render tree, and the incoming values have been assigned to properties.
		/// </summary>
		protected override async Task OnParametersSetAsync()
		{
			if (CheckIsNullOrEmptyOrWhiteSpace(HomePageStaticTexts.Title) || CheckIsNullOrEmptyOrWhiteSpace(HomePageStaticTexts.Copyright)
				|| CheckIsNullOrEmptyOrWhiteSpace(HomePageStaticTexts.SubTitleOne) || CheckIsNullOrEmptyOrWhiteSpace(HomePageStaticTexts.SubTitleTwo)
				|| CheckIsNullOrEmptyOrWhiteSpace(HomePageStaticTexts.English) || CheckIsNullOrEmptyOrWhiteSpace(HomePageStaticTexts.Swedish))
			{
				var staticTexts = await DataService.GetStaticTexts();
				LocaleStaticTexts.SetLocaleStaticTexts(staticTexts);
				HomePageStaticTexts.SetStaticTexts(staticTexts);
			}
			SetDefaultLanguageAndVersion();
			await base.OnParametersSetAsync();
		}

		/// <summary>
		/// Method invoked when the component is ready to start, having received its
		/// initial parameters from its parent in the render tree.
		/// Override this method if you will perform an asynchronous operation and
		/// want the component to refresh when that operation is completed.
		/// </summary>
		protected override async Task OnInitializedAsync()
		{
			Versions = await DataService.GetVersions();
			Languages = await DataService.GetLanguages();
			ParseQueryStringParameters();
			Toc = await DataService.GetTOC();
			await base.OnInitializedAsync();
		}

		/// <summary>
		/// Checks the is null or empty or white space.
		/// </summary>
		/// <param name="staticText">The static text.</param>
		/// <returns>True if it is empty; else false if it has content.</returns>
		private static bool CheckIsNullOrEmptyOrWhiteSpace(string staticText)
		{
			return string.IsNullOrWhiteSpace(staticText);
		}

		/// <summary>
		/// Sets the default version.
		/// </summary>
		private void SetDefaultVersion()
		{
			if (Versions != null && Versions.VersionCollection.Count != 0)
			{
				VersionMenuItem.Text = Versions.VersionCollection.Find(versions => versions.VersionNumber == Settings.Version).VersionDescription;
			}
		}

		/// <summary>
		/// Sets the default language.
		/// </summary>
		private void SetDefaultLanguage()
		{
			if (!string.IsNullOrWhiteSpace(HomePageStaticTexts.English) && !string.IsNullOrWhiteSpace(HomePageStaticTexts.Swedish))
			{
				LanguageMenuItem.Text = string.Equals(Settings.Language, English, StringComparison.OrdinalIgnoreCase) ? HomePageStaticTexts.English : HomePageStaticTexts.Swedish;
			}
		}

		/// <summary>
		/// Handles the menu item click.
		/// </summary>
		/// <param name="menuItem">The <see cref="MenuItemClickEventArgs"/> instance containing the event data.</param>
		private void HandleLanguageMenuItemClick(MenuItemClickEventArgs menuItem)
		{
			LanguageMenuItem.Text = menuItem.ItemInfo.Text;
			StoreLanguageInCache(LanguageMenuItem.Text == HomePageStaticTexts.English ? English : Swedish);
		}

		/// <summary>
		/// Handles the version menu item click.
		/// </summary>
		/// <param name="menuItem">The <see cref="MenuItemClickEventArgs"/> instance containing the event data.</param>
		private void HandleVersionMenuItemClick(MenuItemClickEventArgs menuItem)
		{
			VersionMenuItem.Text = menuItem.ItemInfo.Text;
			StoreVersionInCache(VersionMenuItem.Text);
		}

		/// <summary>
		/// Stores the version in cache.
		/// </summary>
		/// <param name="version">The version.</param>
		private void StoreVersionInCache(string version)
		{
			StoreItemInLocalStorage(VersionKey, version);
			ReloadCurrentPage();
		}

		/// <summary>
		/// Stores the language in cache.
		/// </summary>
		/// <param name="language">The language.</param>
		private void StoreLanguageInCache(string language)
		{
			StoreItemInLocalStorage(LanguageKey, language);
			ReloadCurrentPage();
		}

		/// <summary>
		/// Stores the item in local storage.
		/// </summary>
		/// <param name="storageKey">The storage key.</param>
		/// <param name="storageItem">The storage item.</param>
		private void StoreItemInLocalStorage(string storageKey, string storageItem)
		{
			LocalStorage.SetItem(storageKey, storageItem);
		}

		/// <summary>
		/// Reloads the current page.
		/// </summary>
		private void ReloadCurrentPage()
		{
			NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
		}

		/// <summary>
		/// Parses the query string parameters.
		/// </summary>
		private void ParseQueryStringParameters()
		{
			ParseLanguage();
			ParseVersion();
		}

		/// <summary>
		/// Sets the default language and version.
		/// </summary>
		private void SetDefaultLanguageAndVersion()
		{
			SetDefaultLanguage();
			SetDefaultVersion();
		}

		/// <summary>
		/// Parses the version.
		/// </summary>
		private void ParseVersion()
		{
			QueryHelpers.ParseQuery(GetQueryString()).TryGetValue(VersionKey, out var version);
			if (!string.IsNullOrWhiteSpace(version) && IsVersionExists(version))
				Settings.Version = version;
			else if (LocalStorage.ContainKey(VersionKey) && Versions?.VersionCollection.Count > 0 && IsVersionExists(LocalStorage.GetItem<string>(VersionKey)))
				Settings.Version = LocalStorage.GetItem<string>(VersionKey);
			else
				Settings.Version = "0";
			StoreItemInLocalStorage(VersionKey, Settings.Version);
		}

		/// <summary>
		/// Parses the language.
		/// </summary>
		private void ParseLanguage()
		{
			QueryHelpers.ParseQuery(GetQueryString()).TryGetValue(LanguageKey, out var language);
			if (Languages != null && Languages.Contains(language))
				Settings.Language = language;
			else if (LocalStorage.ContainKey(LanguageKey) && Languages.Contains(LocalStorage.GetItem<string>(LanguageKey)))
				Settings.Language = LocalStorage.GetItem<string>(LanguageKey);
			else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == ISOSwedishCode)
				Settings.Language = Swedish;
			else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == ISOEnglishCode)
				Settings.Language = English;
			else
				Settings.Language = English;
			StoreItemInLocalStorage(LanguageKey, Settings.Language);
		}

		/// <summary>
		/// Gets the query string.
		/// </summary>
		/// <returns>Returns the current query.</returns>
		private string GetQueryString()
		{
			return new Uri(NavigationManager.Uri).Query;
		}

		/// <summary>
		/// Determines whether [is version exists] [the specified version].
		/// </summary>
		/// <param name="version">The version.</param>
		/// <returns>
		///   <c>true</c> if [is version exists] [the specified version]; otherwise, <c>false</c>.
		/// </returns>
		private bool IsVersionExists(string version)
		{
			return Versions.VersionCollection.Exists(versions => versions.VersionNumber == version);
		}
	}
}
