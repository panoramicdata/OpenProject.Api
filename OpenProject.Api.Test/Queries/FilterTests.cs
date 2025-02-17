using OpenProject.Api.Queries;

namespace OpenProject.Api.Test.Queries;

public class FilterTests
{
	[Fact]
	public void Filter_ToString_Succeeds()
	{
		var filters = new Filters(
		[
			new("subjectOrId", new OperatorValues {
				Operator = FilterOperator.SearchInAllStringAttributes,
				Values = ["12"] }),

			new("status", new OperatorValues {
				Operator = FilterOperator.EqualsOneOf,
				Values = ["5"] } ),
		]);

		var filterString = filters.ToString();

		filterString.Should().NotBeNullOrEmpty();
		filterString.Should().Be("""[{"subjectOrId":{"operator":"**","values":["12"]}},{"status":{"operator":"=","values":["5"]}}]""");
	}
}