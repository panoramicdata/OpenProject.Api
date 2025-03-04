using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// Represents a day of the week using an Integer to represent the day
/// <list type="bullet">
/// <item>1 - Monday</item>
/// <item>2 - Tuesday</item>
/// <item>3 - Wednesday</item>
/// <item>4 - Thursday</item>
/// <item>5 - Friday</item>
/// <item>6 - Saturday</item>
/// <item>7 - Sunday</item>
/// </list>
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/work-schedule/'/></para>
/// </summary>
public class WeekDay : ItemBase
{
	/// <summary>
	/// The week day from 1 to 7. 1 is Monday. 7 is Sunday.	
	/// </summary>
	[Range(1, 7)]
	public int Day { get; set; }

	/// <summary>
	/// The name of the week day	
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// true for a working day, false otherwise
	/// </summary>
	[JsonPropertyName("working")]
	public required bool IsWorking { get; set; }
}
