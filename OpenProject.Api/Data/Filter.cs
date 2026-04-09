namespace OpenProject.Api.Data;

/// <summary>
/// Represents a saved filter in OpenProject.
/// </summary>
public class Filter : ItemBase
{
	/// <summary>
	/// The name of the saved filter.
	/// </summary>
	public required string Name { get; set; }
}
