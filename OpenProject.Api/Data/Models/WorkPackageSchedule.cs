using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// The scheduling and estimate fields of a work package. They are top-level fields in OpenProject's JSON;
/// <see cref="IHasSchedule"/> models group them here.
/// </summary>
public class WorkPackageSchedule
{
	/// <summary>
	/// If false (default) schedule automatically.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public bool? ScheduleManually { get; set; }

	/// <summary>
	/// Scheduled beginning of a work package
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public DateTime? StartDate { get; set; }

	/// <summary>
	/// Scheduled end of a work package
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public DateTime? DueDate { get; set; }

	/// <summary>
	/// Date on which a milestone is achieved
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public DateTime? Date { get; set; }

	/// <summary>
	/// Corresponds to work. Time a work package likely needs to be completed.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? EstimatedTime { get; set; }

	/// <summary>
	/// Corresponds to total work. Time a work package likely needs to be completed including itself and its descendants.
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? DerivedEstimatedTime { get; set; }
}
