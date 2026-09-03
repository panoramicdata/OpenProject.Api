namespace OpenProject.Api.Test.Tests;

public class RelationTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Relations.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Relations.GetAsync(element.Id, cancellationToken));
}
