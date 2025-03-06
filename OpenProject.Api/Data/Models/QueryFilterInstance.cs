namespace OpenProject.Api.Data.Models;

/// <summary>
/// A QueryFilterInstance defines filtering applied to the list of work packages.
/// <para>See <a href='https://www.openproject.org/docs/api/endpoints/queries/#query-filter-instance'/></para>
/// </summary>
public class QueryFilterInstance : ItemBase
{
	/// <summary>
	/// The name of the Query Filter Instance
	/// </summary>
	public required string Name { get; set; }

	/// <summary>
	/// Holds a list of primitive types (e.g. Integer, Boolean, Date) stored as strings.
	/// </summary>
	public IEnumerable<string> Values { get; set; } = [];
}
