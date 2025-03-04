using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// Time entries are classified by an activity which is one item of a set of user defined activities (e.g. Design, Specification, Development).
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/time-entry-activities/'/></para>
/// </summary>
public class TimeEntry : IdentifiedItem<int>, IHasTimestamps
{
	/// <summary>
	/// A text provided by the user detailing the time entry
	/// </summary>
	public string Comment { get; set; } = string.Empty;

	/// <summary>
	/// The date the expenditure is booked for
	/// </summary>
	public DateTime? SpentOn { get; set; }

	/// <summary>
	/// The time quantifying the expenditure
	/// </summary>
	public string Hours { get; set; } = string.Empty;

	/// <summary>
	/// Whether the time entry is actively tracking
	/// </summary>
	[JsonPropertyName("ongoing")]
	public bool IsOngoing { get; set; }

	/// <summary>
	/// The time the time entry was created
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The time the time entry was last updated
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}
