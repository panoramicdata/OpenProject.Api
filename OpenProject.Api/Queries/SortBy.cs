using System.Text;

namespace OpenProject.Api.Queries;

public class SortBy(List<FieldAndDirection> sort)
{
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