namespace OpenProject.Api.Interfaces;

/// <summary>
/// Implemented by resources that track creation and modification timestamps.
/// </summary>
public interface IHasTimestamps
{
	/// <summary>
	/// The date and time the resource was created
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// The date and time the resource was last updated
	/// </summary>
	public DateTime UpdatedAt { get; set; }
}
