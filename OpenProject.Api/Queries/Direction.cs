using System.Runtime.Serialization;

namespace OpenProject.Api.Queries;

public enum Direction
{
	[EnumMember(Value = "asc")]
	Ascending,

	[EnumMember(Value = "desc")]
	Descending
}