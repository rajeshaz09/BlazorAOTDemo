using Jeeves.DocsAgent.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jeeves.Docs2.Models
{
	/// <summary>
	/// Methods to get data
	/// </summary>
	public interface IDataService
	{
		/// <summary>
		/// Gets the static texts.
		/// </summary>
		Task<StaticTexts> GetStaticTexts();

		/// <summary>
		/// Gets the toc.
		/// </summary>
		Task<TableOfContents> GetTOC();

		/// <summary>
		/// Gets the versions.
		/// </summary>
		Task<Versions> GetVersions();

		/// <summary>
		/// Gets the languages.
		/// </summary>
		Task<IList<string>> GetLanguages();

		/// <summary>
		/// Gets the chapter.
		/// </summary>
		/// <param name="chapterId">The chapter id.</param>
		Task<Chapter> GetChapter(string chapterId);

		/// <summary>
		/// Gets the program.
		/// </summary>
		/// <param name="programId">The program id.</param>
		Task<DocsAgent.Models.Program> GetProgram(string programId);

		/// <summary>
		/// Gets the table.
		/// </summary>
		/// <param name="tableId">The table id.</param>
		Task<Table> GetTable(string tableId);

		/// <summary>
		/// Gets the field.
		/// </summary>
		/// <param name="fieldId">The field id.</param>
		Task<Field> GetField(string fieldId);

		/// <summary>
		/// Gets the programs.
		/// </summary>
		Task<Programs> GetPrograms();

		/// <summary>
		/// Gets the tables.
		/// </summary>
		Task<Tables> GetTables();

		/// <summary>
		/// Gets the fields.
		/// </summary>
		Task<Fields> GetFields();

	}
}
