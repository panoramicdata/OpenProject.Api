namespace OpenProject.Api.Test;

public class ProjectStatusTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var projectStatusRefetch = await OpenProjectClient
			.ProjectStatuses
			.GetAsync("on_track", default);

		projectStatusRefetch.Should().NotBeNull();
	}
}