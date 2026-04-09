namespace OpenProject.Api.Queries;

/// <summary>
/// Represents a field name paired with a sort direction for use in query sorting.
/// </summary>
public class FieldAndDirection
{
	/// <summary>
	/// The name of the field to sort by.
	/// </summary>
	public required string Field { get; set; }

	/// <summary>
	/// The sort direction (ascending or descending).
	/// </summary>
	public Direction Direction { get; set; }
}