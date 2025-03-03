namespace OpenProject.Api.Test.Tests;

public class StatusTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var projectStatusRefetch = await OpenProjectClient
			.Statuses
			.GetAsync(1, default);

		projectStatusRefetch.Should().NotBeNull();
	}
}
