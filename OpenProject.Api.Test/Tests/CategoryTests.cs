namespace OpenProject.Api.Test.Tests;

public class CategoryTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetForProjectAsync_Succeeds()
	{
		// Get
		var projects = await OpenProjectClient
			.Projects
			.GetAllAsync(CancellationToken);

		projects.Should().NotBeNull();
		projects.Embedded.Should().NotBeNull();

		projects.Embedded.Elements.Should().NotBeNull();

		foreach (var project in projects.Embedded.Elements)
		{
			var projectCategories = await OpenProjectClient
				.Categories
				.GetForProjectAsync(project.Id, CancellationToken);
			projectCategories.Should().NotBeNull();
			projectCategories.Links.Should().NotBeNull();
		}
	}
}