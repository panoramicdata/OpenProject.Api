using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Create;
using Refit;

namespace OpenProject.Api.Test.Tests;

public class QueriesTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : CrudTestBase<Query, OpenProjectItemSet<Query>>(testOutputHelper, fixture)
{
	private const string TestQueryName = "Test Query";

	protected override Task<OpenProjectItemSet<Query>> GetAllAsync(CancellationToken cancellationToken)
		=> OpenProjectClient.Queries.GetAllAsync(cancellationToken);

	protected override Task<OpenProjectItemSet<Query>> GetAsync(Query element, CancellationToken cancellationToken)
		=> OpenProjectClient.Queries.GetAsync(element.Id, cancellationToken);

	protected override Task<IApiResponse> CreateThenDeleteAsync()
		=> AssertCreateThenDeleteAsync(
			cancellationToken => OpenProjectClient.Queries.CreateAsync(
				new QueryCreate { Name = TestQueryName },
				cancellationToken),
			(created, cancellationToken) => OpenProjectClient.Queries.DeleteAsync(created.Id, cancellationToken),
			created => created.Name.Should().Be(TestQueryName));
}
