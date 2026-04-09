namespace OpenProject.Api.Data;

/// <summary>
/// Generic container for embedded resource collections in HAL responses.
/// </summary>
/// <typeparam name="T">The type of embedded items.</typeparam>
public class Embedded<T> where T : ItemBase
{
	/// <summary>
	/// The collection of embedded items.
	/// </summary>
	public IReadOnlyCollection<T>? Elements { get; set; }

	/// <summary>
	/// Error information if any validation errors occurred.
	/// </summary>
	public ErrorDetails? ErrorDetails { get; set; }
}
