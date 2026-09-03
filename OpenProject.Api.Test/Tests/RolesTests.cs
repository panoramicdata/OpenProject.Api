namespace OpenProject.Api.Test.Tests;

public class RolesTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Roles.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Roles.GetAsync(element.Id, cancellationToken));
}
