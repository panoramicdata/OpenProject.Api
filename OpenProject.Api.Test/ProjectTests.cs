namespace OpenProject.Api.Test;

public class ProjectTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		var projects = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		projects.Should().NotBeNull();
		projects.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		var response = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		foreach (var project in response.Embedded.Elements)
		{
			// Get
			var projectRefetch = await OpenProjectClient
				.Projects
				.GetAsync(project.Id, default);

			projectRefetch.Should().NotBeNull();
		}
	}
}
