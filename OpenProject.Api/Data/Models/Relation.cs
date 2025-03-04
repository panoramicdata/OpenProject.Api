namespace OpenProject.Api.Data.Models;

/// <summary>
/// Represents a relation between two work packages.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/relations/'/></para>
/// </summary>
public class Relation : IdentifiedItem<int>, INamed
{
	/// <summary>
	/// The internationalized name of this kind of relation
	/// </summary>
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// Which kind of relation (blocks, precedes, etc.)
	/// </summary>
	public required string Type { get; set; }

	/// <summary>
	/// The kind of relation from the other WP’s perspective
	/// </summary>
	public required string ReverseType { get; set; }

	/// <summary>
	/// Short text further describing the relation	
	/// </summary>
	public string Description { get; set; } = string.Empty;

	/// <summary>
	/// The number of days between closing of from and start of to
	/// </summary>
	[Range(0, int.MaxValue)]
	public int? Lag { get; set; }
}
