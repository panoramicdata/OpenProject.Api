namespace OpenProject.Api.Queries;

public enum FilterOperator
{
	EqualsOneOf,
	ContainsAllOf,
	NotEqualsOneOf,
	GreaterThanOrEquals,
	LessThanOrEquals,
	DaysInPast,
	DaysInFuture,
	LessThanDaysInFuture,
	GreaterThanDaysInFuture,
	LessThanDaysInPast,
	GreaterThanDaysInPast,
	NotNull,
	Null,
	SearchInAllStringAttributes,
	OnDate,
	BetweenDates,
	InWeek,
	Today,
	ContainWords,
	NotContainWords
}