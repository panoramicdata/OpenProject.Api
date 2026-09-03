namespace OpenProject.Api.Test.Tests;

public class HelpTextTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.HelpTexts.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.HelpTexts.GetAsync(element.Id, cancellationToken));
}
