using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Update;

/// <summary>
/// Represents the fields that can be updated on an existing work package.
/// </summary>
public class WorkPackageUpdate
{
	/// <summary>
	/// The value of lockVersion is used to implement optimistic locking.
	/// </summary>
	/// <remarks>Can be found in the Get Request</remarks>
	public required int LockVersion { get; set; }

	/// <summary>
	/// Work package subject
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public string? Status { get; set; }

	/// <summary>
	/// The work package description
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public Formattable? Description { get; set; }

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
