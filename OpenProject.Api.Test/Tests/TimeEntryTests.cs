namespace OpenProject.Api.Test.Tests;

public class TimeEntryTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.TimeEntries.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.TimeEntries.GetAsync(element.Id, cancellationToken));
}
