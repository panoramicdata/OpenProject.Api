namespace OpenProject.Api.Test.Tests;

public class StatusTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Statuses.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Statuses.GetAsync(element.Id, cancellationToken));
}
