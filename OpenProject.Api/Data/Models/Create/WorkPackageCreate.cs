using OpenProject.Api.Data.CustomLinks;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Create;

/// <summary>
/// Represents an object used to create a new User on the OpenProject Instance
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/work-packages/'/></para>
/// </summary>
public class WorkPackageCreate
{
	/// <summary>
	/// Outlines the Subject of the new Work Project
	/// </summary>
	[StringLength(255, MinimumLength = 1)]
	public required string Subject { get; set; }

	/// <summary>
	/// Outlines the Description of the new Work Project
	/// </summary>
	[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
	public Formattable? Description { get; set; }

	/// <summary>
	/// If false (default) schedule automatically.	
	/// </summary>
	public bool ScheduleManually { get; set; }

	/// <summary>
	/// Scheduled beginning of a work package	
	/// </summary>
	public DateTime? StartDate { get; set; }

	/// <summary>
	/// Scheduled end of a work package	
	/// </summary>
	public DateTime? DueDate { get; set; }

	/// <summary>
	/// Corresponds to work. Time a work package likely needs to be completed.	
	/// </summary>
	public string? EstimatedTime { get; set; }

	/// <summary>
	/// When scheduling, whether or not to ignore the non working days being defined. A work package with the flag set to true will be allowed to be scheduled to a non working day.	
	/// </summary>
	public bool IgnoreNonWorkingDays { get; set; }

	/// <summary>
	/// Corresponds to % complete. Amount of total completion for a work package.	
	/// </summary>
	public int? PercentageDone { get; set; }

	/// <inheritdoc cref="WorkPackageCreateLinks"/>
	[JsonPropertyName("_links")]
	public required WorkPackageCreateLinks Links { get; set; }
}
