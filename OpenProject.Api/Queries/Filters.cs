using System.Text;

namespace OpenProject.Api.Queries;

public class Filters(List<KeyValuePair<string, OperatorValues>> filters)
{
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