using OpenProject.Api.Queries;

namespace OpenProject.Api.Test.Tests;

/// <summary>
/// <see cref="SortBy"/> renders the sortBy query syntax; no configuration, network or server needed.
/// </summary>
public class SortByTests
{
	[Fact]
	public void ToString_RendersEachFieldAndDirectionAsAJsonPair()
		=> new SortBy(
		[
			new FieldAndDirection { Field = "id", Direction = Direction.Ascending },
			new FieldAndDirection { Field = "updatedAt", Direction = Direction.Descending }
		])
			.ToString().Should().Be("""[["id","asc"],["updatedAt","desc"]]""");

	[Fact]
	public void ToString_OfNoFields_IsAnEmptyArray()
		=> new SortBy([]).ToString().Should().Be("[]");
}
