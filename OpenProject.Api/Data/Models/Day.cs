using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// A Day is either working or non-working. By default, a working day is considered to have 8 hours, the five days from Monday–Friday are considered working days, and Saturday and Sunday are considered non-working days
/// <para>See <a href='https://www.openproject.org/docs/system-admin-guide/calendars-and-dates/'/></para>
/// </summary>
public class Day : ItemBase
{
	/// <summary>
	/// The date in ISO8601 format (YYYY-MM-DD)	
	/// </summary>
	public required DateTime Date { get; set; }

	/// <summary>
	/// The name of the day	
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// true for a working day, false otherwise	
	/// </summary>
	[JsonPropertyName("working")]
	public required bool IsWorking { get; set; }
}
