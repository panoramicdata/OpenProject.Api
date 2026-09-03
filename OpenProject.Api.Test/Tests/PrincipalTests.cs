namespace OpenProject.Api.Test.Tests;

public class PrincipalTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Principals.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Principals.GetAsync(element.Id, cancellationToken));
}
