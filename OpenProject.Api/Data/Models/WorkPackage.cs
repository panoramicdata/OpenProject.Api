using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;

/// <summary>
/// A work package in OpenProject can basically be everything you need to keep track off within your projects. It can be e.g. a task, a feature, a bug, a risk, a milestone or a project phase.
/// <para>See <a href='https://www.openproject.org/docs/getting-started/work-packages-introduction/'/></para>
/// </summary>
public class WorkPackage : IdentifiedItem<int>, IHasTimestamps
{
	/// <summary>
	/// The version of the item as used for optimistic locking
	/// </summary>
	public int? LockVersion { get; set; }

	/// <summary>
	/// Work package subject
	/// </summary>
	[StringLength(255, MinimumLength = 1)]
	public required string Subject { get; set; }

	// TODO: Add "Type" here. It is not "_type" but a different property altogether

	/// <summary>
	/// The work package description
	/// </summary>
	public Formattable? Description { get; set; }

	/// <summary>
	/// If false (default) schedule automatically.
	/// </summary>
	public bool? ScheduleManually { get; set; }

	/// <summary>
	/// Scheduled beginning of a work package	
	/// </summary>
	public DateTime? StartDate { get; set; }

	/// <summary>
	/// Scheduled end of a work package
	/// </summary>
	public DateTime? DueDate { get; set; }

	/// <summary>
	/// Date on which a milestone is achieved
	/// </summary>
	public DateTime? Date { get; set; }

	/// <summary>
	/// Similar to start date but is not set by a client but rather deduced by the work packages’ descendants. If manual scheduleManually is active, the two dates can deviate.
	/// </summary>
	public DateTime? DerivedStartDate { get; set; }

	/// <summary>
	/// Similar to due date but is not set by a client but rather deduced by the work packages’ descendants. If manual scheduleManually is active, the two dates can deviate.
	/// </summary>
	public DateTime? DerivedDueDate { get; set; }

	/// <summary>
	/// The amount of time in hours the work package needs to be completed.
	/// </summary>
	public string? Duration { get; set; }

	/// <summary>
	/// Corresponds to work. Time a work package likely needs to be completed.
	/// </summary>
	public string? EstimatedTime { get; set; }

	/// <summary>
	/// Corresponds to total work. Time a work package likely needs to be completed including itself and its descendants.	
	/// </summary>
	public string? DerivedEstimatedTime { get; set; }

	/// <summary>
	/// Corresponds to remaining work. Remaining time a work package likely needs to be completed.
	/// </summary>
	public string? RemainingTime { get; set; }

	/// <summary>
	/// Corresponds to total remaining work. Remaining time a work package likely needs to be completed including itself and its descendants.	
	/// </summary>
	public string? DerivedRemainingTime { get; set; }

	/// <summary>
	/// When scheduling, whether or not to ignore the non working days being defined. A work package with the flag set to true will be allowed to be scheduled to a non working day.	
	/// </summary>
	public bool? IgnoreNonWorkingDays { get; set; }

	/// <summary>
	/// The time booked for this work package by users working on it	
	/// </summary>
	public string? SpentTime { get; set; }

	/// <summary>
	/// 
	/// </summary>

	[Range(0, 100)]
	public required int? PercentageDone { get; set; }

	/// <summary>
	/// Corresponds to total % complete. Amount of total completion for a work package and its descendants.
	/// </summary>
	[Range(0, 100)]
	public required int? DerivedPercentageDone { get; set; }

	/// <summary>
	/// If true, the work package is in a readonly status so with the exception of the status, no other property can be altered.
	/// </summary>
	[JsonPropertyName("readonly")]
	public bool? IsReadonly { get; set; }

	/// <summary>
	/// Time of creation
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// Time of the most recent change to the work package
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}