using OpenProject.Api.Data.Models.Create;
using Refit;

namespace OpenProject.Api.Test.Tests;

public class QueriesTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	private const string TestQueryName = "Test Query";

	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.Queries.GetAllAsync);

	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Queries.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Queries.GetAsync(element.Id, cancellationToken));

	[Fact]
	public Task CreateAsync_Succeeds()
		=> CreateThenDeleteAsync();

	[Fact]
	public async Task DeleteAsync_Succeeds()
		=> AssertDeleteSucceeded(await CreateThenDeleteAsync());

	private Task<IApiResponse> CreateThenDeleteAsync()
		=> AssertCreateThenDeleteAsync(
			cancellationToken => OpenProjectClient.Queries.CreateAsync(
				new QueryCreate { Name = TestQueryName },
				cancellationToken),
			(created, cancellationToken) => OpenProjectClient.Queries.DeleteAsync(created.Id, cancellationToken),
			created => created.Name.Should().Be(TestQueryName));
}
