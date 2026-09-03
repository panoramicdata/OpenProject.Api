namespace OpenProject.Api.Test.Tests;

public class DocumentTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Documents.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Documents.GetAsync(element.Id, cancellationToken));
}
