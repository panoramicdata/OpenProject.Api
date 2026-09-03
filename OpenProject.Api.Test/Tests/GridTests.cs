namespace OpenProject.Api.Test.Tests;

public class GridTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Grids.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Grids.GetAsync(element.Id, cancellationToken));
}
