using System.Globalization;

namespace OpenProject.Api.Queries;

public class OperatorValues
{
	public required FilterOperator Operator { get; set; }
	public required List<object?> Values { get; set; }

	public override string ToString() => $"{{\"operator\":\"{GetString(Operator)}\",\"values\":[{string.Join(",", Values.Select(v => $"\"{GetObjectString(v)}\""))}]}}";

	private static string GetObjectString(object? v)
		=> v switch
		{
			string s => s,
			int i => i.ToString(CultureInfo.InvariantCulture),
			DateTime dt => dt.ToString("yyyy-MM-ddTHH:mm:ddZ", CultureInfo.InvariantCulture),
			bool b => b ? "t" : "f",
			_ => v?.ToString() ?? string.Empty
		};

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
			FilterOperator.WorkPackageStatusOpen => "o",
			FilterOperator.WorkPackageStatusClosed => "c",
			FilterOperator.WorkPackageHasManualSortOrder => "ow",
			FilterOperator.WorkPackageBlocks => "blocks",
			FilterOperator.WorkPackageBlocked => "blocked",
			FilterOperator.WorkPackageChildren => "children",
			FilterOperator.WorkPackageParent => "parent",
			FilterOperator.WorkPackageFollows => "follows",
			FilterOperator.WorkPackagePrecedes => "precedes",
			FilterOperator.WorkPackageDuplicates => "duplicates",
			FilterOperator.WorkPackageDuplicated => "duplicated",
			FilterOperator.WorkPackagePartOf => "partof",
			FilterOperator.WorkPackageIncludes => "includes",
			FilterOperator.WorkPackageRelates => "relates",
			FilterOperator.WorkPackageRequires => "requires",
			FilterOperator.WorkPackageRequired => "required",
			_ => throw new ArgumentOutOfRangeException(nameof(@operator), @operator, null)
		};
}
