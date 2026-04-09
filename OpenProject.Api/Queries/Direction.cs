using System.Runtime.Serialization;

namespace OpenProject.Api.Queries;

/// <summary>
/// Specifies the direction for sorting query results.
/// </summary>
public enum Direction
{
	/// <summary>
	/// Sort in ascending order.
	/// </summary>
	[EnumMember(Value = "asc")]
	Ascending,

	/// <summary>
	/// Sort in descending order.
	/// </summary>
	[EnumMember(Value = "desc")]
	Descending
}