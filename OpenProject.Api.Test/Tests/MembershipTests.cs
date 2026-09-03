namespace OpenProject.Api.Test.Tests;

public class MembershipTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.Memberships.GetAllAsync);

	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Memberships.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Memberships.GetAsync(element.Id, cancellationToken));
}
