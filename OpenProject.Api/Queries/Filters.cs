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
			var filterString = $"{{\"{filter.Key}\":{{\"operator\":\"{GetString(filter.Value.Operator)}\",\"values\":[{string.Join(",", filter.Value.Values.Select(v => $"\"{v}\""))}]}}}}";
			filtersString.Append(filterString);

			if (++index < filters.Count)
			{
				filtersString.Append(',');
			}
		}
		filtersString.Append(']');
		return filtersString.ToString();
	}

	/// <summary>
	/// See https://www.openproject.org/docs/api/filters/
	/// </summary>
	/// <param name="operator"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	private static string GetString(FilterOperator @operator)
		=> @operator switch
		{
			FilterOperator.EqualsOneOf => "=",
			FilterOperator.ContainsAllOf => "&=",
			FilterOperator.NotEqualsOneOf => "gt",
			FilterOperator.GreaterThanOrEquals => ">=",
			FilterOperator.LessThanOrEquals => "<=",
			FilterOperator.DaysInPast => "t-",
			FilterOperator.DaysInFuture => "t+",
			FilterOperator.LessThanDaysInFuture => "<t+",
			FilterOperator.GreaterThanDaysInFuture => ">t+",
			FilterOperator.LessThanDaysInPast => ">t-",
			FilterOperator.GreaterThanDaysInPast => "<t-",
			FilterOperator.NotNull => "*",
			FilterOperator.Null => "!*",
			FilterOperator.SearchInAllStringAttributes => "**",
			FilterOperator.OnDate => "=d",
			FilterOperator.BetweenDates => "<>d",
			FilterOperator.InWeek => "w",
			FilterOperator.Today => "t",
			FilterOperator.ContainWords => "~",
			FilterOperator.NotContainWords => "!~",
			_ => throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null)
		};
}