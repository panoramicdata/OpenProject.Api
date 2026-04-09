namespace OpenProject.Api.Queries;

/// <summary>
/// Available filter operators for querying OpenProject API endpoints.
/// <para>See <a href="https://www.openproject.org/docs/api/filters/">API Filters documentation</a>.</para>
/// </summary>
public enum FilterOperator
{
	/// <summary>
	/// Are equal to one of the given value(s). Operator: <c>=</c>
	/// </summary>
	EqualsOneOf,

	/// <summary>
	/// Are containing all of the given value(s). Operator: <c>&amp;=</c>
	/// </summary>
	ContainsAllOf,

	/// <summary>
	/// Are not equal to one of the given value(s). Operator: <c>!</c>
	/// </summary>
	NotEqualsOneOf,

	/// <summary>
	/// Are greater than or equal to the given value. Operator: <c>&gt;=</c>
	/// </summary>
	GreaterThanOrEquals,

	/// <summary>
	/// Are less than or equal to the given value. Operator: <c>&lt;=</c>
	/// </summary>
	LessThanOrEquals,

	/// <summary>
	/// Are the given number of days in the past. Operator: <c>t-</c>
	/// </summary>
	DaysInPast,

	/// <summary>
	/// Are the given number of days in the future. Operator: <c>t+</c>
	/// </summary>
	DaysInFuture,

	/// <summary>
	/// Are less than the given number of days in the future. Operator: <c>&lt;t+</c>
	/// </summary>
	LessThanDaysInFuture,

	/// <summary>
	/// Are more than the given number of days in the future. Operator: <c>&gt;t+</c>
	/// </summary>
	GreaterThanDaysInFuture,

	/// <summary>
	/// Are more than the given number of days in the past. Operator: <c>&lt;t-</c>
	/// </summary>
	LessThanDaysInPast,

	/// <summary>
	/// Are less than the given number of days in the past. Operator: <c>&gt;t-</c>
	/// </summary>
	GreaterThanDaysInPast,

	/// <summary>
	/// Are not NULL (have a value). Operator: <c>*</c>
	/// </summary>
	NotNull,

	/// <summary>
	/// Are NULL (have no value). Operator: <c>!*</c>
	/// </summary>
	Null,

	/// <summary>
	/// Searches the given string in all string-based attributes. Operator: <c>**</c>
	/// </summary>
	SearchInAllStringAttributes,

	/// <summary>
	/// Are on the given date. Operator: <c>=d</c>
	/// </summary>
	OnDate,

	/// <summary>
	/// Are between the two given dates. Operator: <c>&lt;&gt;d</c>
	/// </summary>
	BetweenDates,

	/// <summary>
	/// Are in the current week. Operator: <c>w</c>
	/// </summary>
	InWeek,

	/// <summary>
	/// Are today. Operator: <c>t</c>
	/// </summary>
	Today,

	/// <summary>
	/// Are containing the given words (SQL LIKE) in that order. Operator: <c>~</c>
	/// </summary>
	ContainWords,

	/// <summary>
	/// Are not containing the given words (SQL LIKE) in that order. Operator: <c>!~</c>
	/// </summary>
	NotContainWords,

	/// <summary>
	/// The status of the work package is open. Operator: <c>o</c>
	/// </summary>
	WorkPackageStatusOpen,

	/// <summary>
	/// The status of the work package is closed. Operator: <c>c</c>
	/// </summary>
	WorkPackageStatusClosed,

	/// <summary>
	/// The work package has a manual sort order. Operator: <c>ow</c>
	/// </summary>
	WorkPackageHasManualSortOrder,

	/// <summary>
	/// The work package blocks another work package. Operator: <c>blocks</c>
	/// </summary>
	WorkPackageBlocks,

	/// <summary>
	/// The work package is blocked by another work package. Operator: <c>blocked</c>
	/// </summary>
	WorkPackageBlocked,

	/// <summary>
	/// The work package has children. Operator: <c>children</c>
	/// </summary>
	WorkPackageChildren,

	/// <summary>
	/// The work package has a parent. Operator: <c>parent</c>
	/// </summary>
	WorkPackageParent,

	/// <summary>
	/// The work package follows another work package. Operator: <c>follows</c>
	/// </summary>
	WorkPackageFollows,

	/// <summary>
	/// The work package precedes another work package. Operator: <c>precedes</c>
	/// </summary>
	WorkPackagePrecedes,

	/// <summary>
	/// The work package duplicates another work package. Operator: <c>duplicates</c>
	/// </summary>
	WorkPackageDuplicates,

	/// <summary>
	/// The work package is duplicated by another work package. Operator: <c>duplicated</c>
	/// </summary>
	WorkPackageDuplicated,

	/// <summary>
	/// The work package includes another work package. Operator: <c>includes</c>
	/// </summary>
	WorkPackageIncludes,

	/// <summary>
	/// The work package relates to another work package. Operator: <c>relates</c>
	/// </summary>
	WorkPackageRelates,

	/// <summary>
	/// The work package requires another work package. Operator: <c>requires</c>
	/// </summary>
	WorkPackageRequires,

	/// <summary>
	/// The work package is required by another work package. Operator: <c>required</c>
	/// </summary>
	WorkPackageRequired,

	/// <summary>
	/// The work package is part of another work package. Operator: <c>partof</c>
	/// </summary>
	WorkPackagePartOf
}