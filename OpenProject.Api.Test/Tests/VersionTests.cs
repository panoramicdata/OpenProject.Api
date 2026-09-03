namespace OpenProject.Api.Test.Tests;

public class VersionTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Versions.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Versions.GetAsync(element.Id, cancellationToken));

	[Fact]
	public Task GetAvailableProjectsAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.Versions.GetAvailableProjectsAsync);
}
