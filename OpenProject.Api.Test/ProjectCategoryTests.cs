namespace OpenProject.Api.Test;

public class ProjectCategoryTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetForProjectAsync_Succeeds()
	{
		// Get
		var projects = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		projects.Should().NotBeNull();
		projects.Embedded.Should().NotBeNull();

		foreach (var project in projects.Embedded.Elements)
		{
			var projectCategories = await OpenProjectClient
				.ProjectCategories
				.GetForProjectAsync(project.Id, default);
			projectCategories.Should().NotBeNull();
			projectCategories.Links.Should().NotBeNull();
		}
	}
}