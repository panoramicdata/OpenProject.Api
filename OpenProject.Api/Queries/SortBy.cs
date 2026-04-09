using System.Text;

namespace OpenProject.Api.Queries;

/// <summary>
/// Represents a sort specification that serializes to the JSON sortBy syntax for API queries.
/// </summary>
/// <param name="sort">The list of field-direction pairs defining the sort order.</param>
public class SortBy(List<FieldAndDirection> sort)
{
	/// <summary>
	/// Returns the JSON-encoded sortBy string suitable for use as an API query parameter.
	/// </summary>
	public override string ToString()
	{
		var sortString = new StringBuilder();
		var index = 0;
		sortString.Append('[');
		foreach (var sortItem in sort)
		{
			var sortItemString = $"""["{sortItem.Field}","{sortItem.Direction switch { Direction.Ascending => "asc", _ => "desc" }}"]""";
			sortString.Append(sortItemString);
			if (++index < sort.Count)
			{
				sortString.Append(',');
			}
		}
		sortString.Append(']');
		return sortString.ToString();
	}
}