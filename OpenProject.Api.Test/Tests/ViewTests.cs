namespace OpenProject.Api.Test.Tests;

public class ViewTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Views.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Views.GetAsync(element.Id, cancellationToken));
}
