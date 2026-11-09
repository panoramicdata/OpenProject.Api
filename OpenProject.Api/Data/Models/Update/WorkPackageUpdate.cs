using OpenProject.Api.Data.Models;
using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models.Update;

/// <summary>
/// Represents the fields that can be updated on an existing work package.
/// </summary>
public class WorkPackageUpdate : IHasSchedule
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
	/// Scheduling and estimate fields to change; fields left null are not sent.
	/// </summary>
	[JsonIgnore]
	public WorkPackageSchedule Schedule { get; set; } = new();
}
