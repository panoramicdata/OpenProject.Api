namespace OpenProject.Api.Test.Tests;

public class ActionTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Actions.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Actions.GetAsync(element.Id, cancellationToken));
}
