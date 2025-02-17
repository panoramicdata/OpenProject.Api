namespace OpenProject.Api.Test.Tests;

public class ProjectTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		var items = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		var items = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		foreach (var project in items.Embedded.Elements)
		{
			// Get
			var projectRefetch = await OpenProjectClient
				.Projects
				.GetAsync(project.Id, default);

			projectRefetch.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task GetAvailableAssigneesAsync_Succeeds()
	{
		var items = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		foreach (var item in items.Embedded.Elements)
		{
			// Get
			var availableAssignees = await OpenProjectClient
				.Projects
				.GetAvailableAssigneesAsync(item.Id, default);

			availableAssignees.Should().NotBeNull();
		}
	}
}
