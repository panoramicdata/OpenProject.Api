namespace OpenProject.Api.Test;

public class ProjectTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		var projectCollection = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		var projects = projectCollection.Embedded.Elements;
	}

	[Fact]
	public async Task GetStatusAsync_Succeeds()
	{
		var response = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		foreach (var project in response.Embedded.Elements)
		{
			// Get Status
			var status = await OpenProjectClient
				.Projects
				.GetStatusAsync(project.Id, default);
		}
	}
}