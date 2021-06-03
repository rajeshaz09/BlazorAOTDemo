using Jeeves.Docs.Models;
using Jeeves.DocsAgent.Models;
using System;

namespace Jeeves.Docs.Extensions
{
	/// <summary>
	/// Utility methods
	/// </summary>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:Avoid excessive complexity")]
	public static class DocExtensions
	{
		#region Private Fields
		private const string Copyright = "© Copyright Jeeves Information Systems. All rights reserved";
		private const string Title = "Welcome to JIS documentation web";
		private const string SubTitleOne = "Here you can explore all about Jeeves ERP's functionality.";
		private const string SubTitleTwo = "To find what you are looking for use the contents or search.";
		private const string ErrorHeader = "Oops!";
		private const string ErrorMessage = "Something went wrong.Please click Home or Back.";
		private const string ErrorRequest = "An error occured at the request of";
		private const string FilterText = "Type to filter table of contents...";
		private const string ResultHits = "No. of hits";
		private const string NoResultsFound = "Search resulted in no hits";
		private const string ProgramsFilterText = "Type to filter programs...";
		private const string TablesFilterText = "Type to filter tables...";
		private const string FieldsFilterText = "Type to filter fields...";
		private const string Application = "Application";
		private const string ProgramName = "Program name";
		private const string DataName = "Data name";
		private const string TableName = "Table name";
		private const string Prompt = "Prompt";
		private const string ColumnHeader = "Column header";
		private const string Description = "Description";
		private const string ProgramsDescription = "This table is the main table in the following program(s):";
		private const string FieldsDescription = "The table consists of the following fields:";
		private const string ProgramTitle = "Program:";
		private const string TableTitle = "Table:";
		private const string FieldTitle = "Field:";
		private const string PrintReport = "Print report:";
		private const string RelevantImportantFields = "Relevant/important field(s)/button(s):";
		private const string RecordsDescription = "Following standard records exist. Do not alter/delete codes:";
		private const string NumberOfCharacters = "Number of characters";
		private const string JeevesDataType = "Jeeves data type";
		private const string SQLDataType = "SQL data type";
		private const string DecimalPlaces = "Decimal places";
		private const string TablesDescription = "The term is included in the following tables:";
		private const string ChaptersDescription = "How the program is used is described in chapter(s):";
		private const string NodesDescription = "Connected programs (nodes)/report windows:";
		private const string ReportsDescription = "Report(s) available in this program:";
		private const string TableDescription = "Main table for this program:";
		private const string English = "English";
		private const string Swedish = "Svenska";
		private const string ImageNotFound = "Image not found";
		private const string ScrollToTop = "Scroll to top";
		private const string ScrollToTopTitle = "Scroll up to top of chapter";
		#endregion

		/// <summary>
		/// Gets the static text.
		/// </summary>
		/// <param name="homePageTexts">The home page texts.</param>
		/// <param name="staticTexts">The static texts.</param>
		/// <returns>The static text as per the respected text code.</returns>
		public static void SetStaticTexts(this HomePageStaticTexts homePageTexts, StaticTexts staticTexts)
		{
			ValidateInputParameters(homePageTexts);

			if (staticTexts != null)
			{
				foreach (var v in staticTexts.Items)
				{
					switch (v.Id)
					{
						case (int)TextCode.CopyRight when homePageTexts.Copyright == null:
							homePageTexts.Copyright = v.Description;
							break;
						case (int)TextCode.English when homePageTexts.English == null:
							homePageTexts.English = v.Description;
							break;
						case (int)TextCode.Swedish when homePageTexts.Swedish == null:
							homePageTexts.Swedish = v.Description;
							break;
						case (int)TextCode.Title when homePageTexts.Title == null:
							homePageTexts.Title = v.Description;
							break;
						case (int)TextCode.SubTitleOne when homePageTexts.SubTitleOne == null:
							homePageTexts.SubTitleOne = v.Description;
							break;
						case (int)TextCode.SubTitleTwo when homePageTexts.SubTitleTwo == null:
							homePageTexts.SubTitleTwo = v.Description;
							break;
						default:
							break;
					}
				}
			}
			SetDefaultHomePageStaticTexts(homePageTexts);
		}

		/// <summary>
		/// Sets the locale static texts.
		/// </summary>
		/// <param name="localeStaticTexts">The locale static texts.</param>
		/// <param name="staticTexts">The static texts.</param>
		public static void SetLocaleStaticTexts(this LocaleStaticTexts localeStaticTexts, StaticTexts staticTexts)
		{
			ValidateInputParameters(localeStaticTexts);

			if (staticTexts != null)
			{
				foreach (var v in staticTexts.Items)
				{
					switch (v.Id)
					{
						case (int)TextCode.ErrorHeader:
							localeStaticTexts.ErrorHeader = v.Description;
							break;
						case (int)TextCode.ErrorMessage:
							localeStaticTexts.ErrorMessage = v.Description;
							break;
						case (int)TextCode.ErrorRequest:
							localeStaticTexts.ErrorRequest = v.Description;
							break;
						case (int)TextCode.FilterText:
							localeStaticTexts.FilterText = v.Description;
							break;
						case (int)TextCode.ProgramsFilterText:
							localeStaticTexts.ProgramsFilterText = v.Description;
							break;
						case (int)TextCode.TablesFilterText:
							localeStaticTexts.TablesFilterText = v.Description;
							break;
						case (int)TextCode.FieldsFilterText:
							localeStaticTexts.FieldsFilterText = v.Description;
							break;
						case (int)TextCode.ResultHits:
							localeStaticTexts.ResultHits = v.Description;
							break;
						case (int)TextCode.NoResultsFound:
							localeStaticTexts.NoResultsFound = v.Description;
							break;
						case (int)TextCode.Application:
							localeStaticTexts.Application = v.Description;
							break;
						case (int)TextCode.ProgramName:
							localeStaticTexts.ProgramName = v.Description;
							break;
						case (int)TextCode.DataName:
							localeStaticTexts.DataName = v.Description;
							break;
						case (int)TextCode.TableName:
							localeStaticTexts.TableName = v.Description;
							break;
						case (int)TextCode.Prompt:
							localeStaticTexts.Prompt = v.Description;
							break;
						case (int)TextCode.ColumnHeader:
							localeStaticTexts.ColumnHeader = v.Description;
							break;
						case (int)TextCode.Description:
							localeStaticTexts.Description = v.Description;
							break;
						case (int)TextCode.ProgramsDescription:
							localeStaticTexts.ProgramsDescription = v.Description;
							break;
						case (int)TextCode.FieldsDescription:
							localeStaticTexts.FieldsDescription = v.Description;
							break;
						case (int)TextCode.ProgramTitle:
							localeStaticTexts.ProgramTitle = v.Description;
							break;
						case (int)TextCode.FieldTitle:
							localeStaticTexts.FieldTitle = v.Description;
							break;
						case (int)TextCode.TableTitle:
							localeStaticTexts.TableTitle = v.Description;
							break;
						case (int)TextCode.RelevantImportantFields:
							localeStaticTexts.RelevantImportantFields = v.Description;
							break;
						case (int)TextCode.PrintReport:
							localeStaticTexts.PrintReport = v.Description;
							break;
						case (int)TextCode.RecordsDescription:
							localeStaticTexts.RecordsDescription = v.Description;
							break;
						case (int)TextCode.NumberOfCharacters:
							localeStaticTexts.NumberOfCharacters = v.Description;
							break;
						case (int)TextCode.JeevesDataType:
							localeStaticTexts.JeevesDataType = v.Description;
							break;
						case (int)TextCode.SQLDataType:
							localeStaticTexts.SQLDataType = v.Description;
							break;
						case (int)TextCode.DecimalPlaces:
							localeStaticTexts.DecimalPlaces = v.Description;
							break;
						case (int)TextCode.TablesDescription:
							localeStaticTexts.TablesDescription = v.Description;
							break;
						case (int)TextCode.ChaptersDescription:
							localeStaticTexts.ChaptersDescription = v.Description;
							break;
						case (int)TextCode.ReportsDescription:
							localeStaticTexts.ReportsDescription = v.Description;
							break;
						case (int)TextCode.NodesDescription:
							localeStaticTexts.NodesDescription = v.Description;
							break;
						case (int)TextCode.TableDescription:
							localeStaticTexts.TableDescription = v.Description;
							break;
						case (int)TextCode.ImageNotFound:
							localeStaticTexts.ImageNotFound = v.Description;
							break;
						case (int)TextCode.ScrollToTop:
							localeStaticTexts.ScrollToTop = v.Description;
							break;
						case (int)TextCode.ScrollToTopTitle:
							localeStaticTexts.ScrollToTopTitle = v.Description;
							break;
					}
				}
			}
			SetDefaultLocaleStaticTexts(localeStaticTexts);
		}

		/// <summary>
		/// Sets the default static texts.
		/// </summary>
		/// <param name="localeStaticTexts">The locale static texts.</param>
		private static void SetDefaultLocaleStaticTexts(LocaleStaticTexts localeStaticTexts)
		{
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ErrorHeader))
				localeStaticTexts.ErrorHeader = ErrorHeader;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ErrorMessage))
				localeStaticTexts.ErrorMessage = ErrorMessage;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ErrorRequest))
				localeStaticTexts.ErrorRequest = ErrorRequest;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.FilterText))
				localeStaticTexts.FilterText = FilterText;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ResultHits))
				localeStaticTexts.ResultHits = ResultHits;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.NoResultsFound))
				localeStaticTexts.NoResultsFound = NoResultsFound;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ProgramsFilterText))
				localeStaticTexts.ProgramsFilterText = ProgramsFilterText;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.TablesFilterText))
				localeStaticTexts.TablesFilterText = TablesFilterText;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.FieldsFilterText))
				localeStaticTexts.FieldsFilterText = FieldsFilterText;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.Application))
				localeStaticTexts.Application = Application;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ProgramName))
				localeStaticTexts.ProgramName = ProgramName;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.DataName))
				localeStaticTexts.DataName = DataName;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.TableName))
				localeStaticTexts.TableName = TableName;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.Prompt))
				localeStaticTexts.Prompt = Prompt;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ColumnHeader))
				localeStaticTexts.ColumnHeader = ColumnHeader;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.Description))
				localeStaticTexts.Description = Description;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ProgramsDescription))
				localeStaticTexts.ProgramsDescription = ProgramsDescription;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.FieldsDescription))
				localeStaticTexts.FieldsDescription = FieldsDescription;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ProgramTitle))
				localeStaticTexts.ProgramTitle = ProgramTitle;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.FieldTitle))
				localeStaticTexts.FieldTitle = FieldTitle;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.TableTitle))
				localeStaticTexts.TableTitle = TableTitle;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.RelevantImportantFields))
				localeStaticTexts.RelevantImportantFields = RelevantImportantFields;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.PrintReport))
				localeStaticTexts.PrintReport = PrintReport;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.RecordsDescription))
				localeStaticTexts.RecordsDescription = RecordsDescription;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.NumberOfCharacters))
				localeStaticTexts.NumberOfCharacters = NumberOfCharacters;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.JeevesDataType))
				localeStaticTexts.JeevesDataType = JeevesDataType;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.SQLDataType))
				localeStaticTexts.SQLDataType = SQLDataType;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.DecimalPlaces))
				localeStaticTexts.DecimalPlaces = DecimalPlaces;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.TablesDescription))
				localeStaticTexts.TablesDescription = TablesDescription;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ChaptersDescription))
				localeStaticTexts.ChaptersDescription = ChaptersDescription;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.NodesDescription))
				localeStaticTexts.NodesDescription = NodesDescription;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ReportsDescription))
				localeStaticTexts.ReportsDescription = ReportsDescription;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.TableDescription))
				localeStaticTexts.TableDescription = TableDescription;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ImageNotFound))
				localeStaticTexts.ImageNotFound = ImageNotFound;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ScrollToTop))
				localeStaticTexts.ScrollToTop = ScrollToTop;
			if (string.IsNullOrWhiteSpace(localeStaticTexts.ScrollToTopTitle))
				localeStaticTexts.ScrollToTopTitle = ScrollToTopTitle;
		}

		/// <summary>
		/// Sets the default home page static texts.
		/// </summary>
		/// <param name="homePageTexts">The home page texts.</param>
		private static void SetDefaultHomePageStaticTexts(HomePageStaticTexts homePageTexts)
		{
			if (string.IsNullOrWhiteSpace(homePageTexts.Title))
				homePageTexts.Title = Title;
			if (string.IsNullOrWhiteSpace(homePageTexts.SubTitleOne))
				homePageTexts.SubTitleOne = SubTitleOne;
			if (string.IsNullOrWhiteSpace(homePageTexts.SubTitleTwo))
				homePageTexts.SubTitleTwo = SubTitleTwo;
			if (string.IsNullOrWhiteSpace(homePageTexts.Copyright))
				homePageTexts.Copyright = Copyright;
			if (string.IsNullOrWhiteSpace(homePageTexts.English))
				homePageTexts.English = English;
			if (string.IsNullOrWhiteSpace(homePageTexts.Swedish))
				homePageTexts.Swedish = Swedish;
		}

		/// <summary>
		/// Validates the input paramters.
		/// </summary>
		/// <typeparam name="T">The type to accept.</typeparam>
		/// <param name="genericStaticTexts">The generic static texts.</param>
		private static void ValidateInputParameters<T>(T genericStaticTexts)
		{
			if (genericStaticTexts is null)
			{
				throw new ArgumentNullException(nameof(genericStaticTexts));
			}
		}
	}
}
