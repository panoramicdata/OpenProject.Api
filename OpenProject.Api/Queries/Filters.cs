using System.Text;

namespace OpenProject.Api.Queries;

/// <summary>
/// Represents a collection of API query filters that serializes to the JSON filter syntax.
/// <para>See <a href="https://www.openproject.org/docs/api/filters/">API Filters documentation</a>.</para>
/// </summary>
/// <param name="filters">The list of filter key-value pairs, where each key is the filter name and the value contains the operator and values.</param>
public class Filters(List<KeyValuePair<string, OperatorValues>> filters)
{
	/// <summary>
	/// Returns the JSON-encoded filter string suitable for use as an API query parameter.
	/// </summary>
	public override string ToString()
	{
		var filtersString = new StringBuilder();
		var index = 0;
		filtersString.Append('[');
		foreach (var filter in filters)
		{
			var filterString = $"{{\"{filter.Key}\":{filter.Value}}}";
			filtersString.Append(filterString);

			if (++index < filters.Count)
			{
				filtersString.Append(',');
			}
		}
		filtersString.Append(']');
		return filtersString.ToString();
	}
}