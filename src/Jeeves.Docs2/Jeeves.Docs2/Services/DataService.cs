using Jeeves.Docs2.Models;
using Jeeves.DocsAgent.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Jeeves.Docs2.Services
{
	/// <summary>
	/// Gets data
	/// </summary>
	/// <seealso cref="Jeeves.Docs.Models.IDataService" />
	public class DataService : IDataService
	{
		private const string JsonType = ".json";
		private const string MessagePackType = ".mp";

		private readonly string _documentFileType;
		private readonly HttpClient _httpClient;
		private readonly Settings _settings;
		private readonly NavigationManager _navigationManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataService" /> class.
		/// </summary>
		/// <param name="httpClient">The HTTP client.</param>
		/// <param name="settings">The settings.</param>
		/// <param name="navigationManager">The navigation manager.</param>
		/// <param name="configuration">The configuration.</param>
		public DataService(HttpClient httpClient, Settings settings, NavigationManager navigationManager, IConfiguration configuration)
		{
			_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
			_settings = settings ?? throw new ArgumentNullException(nameof(settings));
			_navigationManager = navigationManager ?? throw new ArgumentNullException(nameof(navigationManager));

			if (configuration == null)
				throw new ArgumentNullException(nameof(configuration));

			_documentFileType = (configuration["DataFormat"]?.ToLower() == "messagepack") ? MessagePackType : JsonType;
		}

		/// <summary>
		/// Gets the static texts.
		/// </summary>
		public Task<StaticTexts> GetStaticTexts()
		{
			return GetData<StaticTexts>("static");
		}

		/// <summary>
		/// Gets the versions.
		/// </summary>
		public Task<Versions> GetVersions()
		{
			return GetData<Versions>("versions");
		}

		/// <summary>
		/// Gets the languages.
		/// </summary>
		public Task<IList<string>> GetLanguages()
		{
			return Task.FromResult<IList<string>>(new List<string>() { "0", "999" });
		}

		/// <summary>
		/// Gets the toc.
		/// </summary>
		public Task<TableOfContents> GetTOC()
		{
			return GetData<TableOfContents>("toc");
		}

		/// <summary>
		/// Gets the chapter.
		/// </summary>
		/// <param name="chapterId">The chapter id.</param>
		public Task<Chapter> GetChapter(string chapterId)
		{
			return GetData<Chapter>($"chapter/{chapterId ?? string.Empty}");
		}

		/// <summary>
		/// Gets the program.
		/// </summary>
		/// <param name="programId">The program id.</param>
		public Task<DocsAgent.Models.Program> GetProgram(string programId)
		{
			return GetData<DocsAgent.Models.Program>($"program/{programId ?? string.Empty}");
		}

		/// <summary>
		/// Gets the table.
		/// </summary>
		/// <param name="tableId">The table id.</param>
		public Task<Table> GetTable(string tableId)
		{
			return GetData<Table>($"table/{tableId ?? string.Empty}");
		}

		/// <summary>
		/// Gets the field.
		/// </summary>
		/// <param name="fieldId">The field id.</param>
		public Task<Field> GetField(string fieldId)
		{
			return GetData<Field>($"field/{fieldId ?? string.Empty}");
		}

		/// <summary>
		/// Gets the programs.
		/// </summary>
		/// <returns>Programs<see cref="Programs"/></returns>
		public Task<Programs> GetPrograms()
		{
			return GetData<Programs>("programs");
		}

		/// <summary>
		/// Gets the tables.
		/// </summary>
		/// <returns>Tables<see cref="Tables"/></returns>
		public Task<Tables> GetTables()
		{
			return GetData<Tables>("tables");
		}

		/// <summary>
		/// Gets the fields.
		/// </summary>
		/// <returns>Fields<see cref="Fields"/></returns>
		public Task<Fields> GetFields()
		{
			return GetData<Fields>("fields");
		}

		/// <summary>
		/// Gets the data from the json files.
		/// </summary>
		/// <typeparam name="Model">The type of the model.</typeparam>
		/// <param name="file">The name of the file.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2234:Pass system uri objects instead of strings", Justification = "<Pending>")]
		private async Task<Model> GetData<Model>(string file)
		{
			string relativePath;
			if (!string.Equals(file, "versions", StringComparison.OrdinalIgnoreCase))
			{
			   relativePath = $"{_settings.Version}/{_settings.Language}/{file.ToLower()}{_documentFileType}";
			}
			else
			{
			   relativePath = $"{file.ToLower()}{_documentFileType}";
			}

			try
			{
				var filePath = Path.GetExtension(relativePath);
				switch (filePath)
				{
					case JsonType:
						return await _httpClient.GetFromJsonAsync<Model>(relativePath);
					//case MessagePackType:
					//	var contents = await _httpClient.GetStreamAsync(relativePath);
					//	return MessagePack.MessagePackSerializer.Deserialize<Model>(contents);
					default:
						return default(Model);
				}
			}
			catch (Exception)
			{
				if (!_navigationManager.ToBaseRelativePath(_navigationManager.Uri).StartsWith("Error", StringComparison.OrdinalIgnoreCase))
				{
					_settings.Error = relativePath;
					if (_settings.IsMenuItemClicked == false)
					{
						return default;
					}
					else
					{
						_navigationManager.NavigateTo($"/Error");
						return default;
					}
				}
				else
				{
					return default;
				}
			}
			finally{
				_settings.IsMenuItemClicked = _settings.IsMenuItemClicked != true && _settings.IsMenuItemClicked;
			}
		}
	}
}
