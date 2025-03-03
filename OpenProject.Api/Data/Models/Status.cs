namespace OpenProject.Api.Data.Models;

/// <summary>
/// Serves information for yourself and the team if the project is on track.
/// <para>See <a href='https://www.openproject.org/docs/user-guide/projects/project-status/'/></para>
/// </summary>
public class Status : IdentifiedItem<int>, INamed
{
	/// <summary>
	/// The status Name
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Status name	
	/// </summary>
	public bool IsClosed { get; set; }

	/// <summary>
	/// A Hex-coded value of the color assigned to the status.
	/// </summary>
	public string Color { get; set; } = string.Empty;

	/// <summary>
	/// True, if this status is the default status for new work packages
	/// </summary>
	public bool IsDefault { get; set; }

	/// <summary>
	/// Indicates, whether work package of this status are readonly
	/// </summary>
	public bool IsReadonly { get; set; }

	/// <summary>
	/// Indicates, whether work package of this status are excluded from totals of Work, Remaining work, and % Complete in a hierarchy.
	/// </summary>
	public bool ExcludedFromTotals { get; set; }

	/// <summary>
	/// The percentageDone being applied when changing to this status
	/// </summary>
	[Range(0, 100)]
	public int DefaultDoneRatio { get; set; }

	/// <summary>
	/// Sort index of the status
	/// </summary>
	public int Position { get; set; }
}
