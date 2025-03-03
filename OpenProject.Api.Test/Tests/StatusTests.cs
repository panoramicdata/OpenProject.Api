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
			.GetAsync("on_track", default);

		projectStatusRefetch.Should().NotBeNull();
	}
}
