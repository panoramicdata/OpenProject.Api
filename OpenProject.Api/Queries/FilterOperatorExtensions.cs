namespace OpenProject.Api.Queries;

internal static class FilterOperatorExtensions
{
	/// <summary>
	/// Returns the wire representation of the operator.
	/// See https://www.openproject.org/docs/api/filters/
	/// </summary>
	/// <param name="operator">The operator to convert.</param>
	/// <returns>The string used in an API filter expression.</returns>
	/// <exception cref="ArgumentOutOfRangeException">The operator is not a recognised <see cref="FilterOperator"/>.</exception>
	internal static string ToFilterString(this FilterOperator @operator)
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
