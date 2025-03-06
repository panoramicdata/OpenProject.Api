using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Data.Models.Update;

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

		items.Embedded.Elements.Should().NotBeNull();

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
	public async Task CreateAsync_Succeeds()
	{
		var project = new ProjectCreate
		{
			Name = "Test Project",
			Identifier = "test-project",
		};

		// Create
		var createdProject = await OpenProjectClient
			.Projects
			.CreateAsync(project, default);
		createdProject.Should().NotBeNull();

		// Delete
		await OpenProjectClient
			.Projects
			.DeleteAsync(createdProject.Id, default);
	}

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		var project = new ProjectCreate
		{
			Name = "Test Project",
			Identifier = "test-project",
		};

		// Create
		var createdProject = await OpenProjectClient
			.Projects
			.CreateAsync(project, default);
		createdProject.Should().NotBeNull();

		// Delete
		var response = await OpenProjectClient
			.Projects
			.DeleteAsync(createdProject.Id, default);

		response.IsSuccessStatusCode.Should().BeTrue();
	}

	[Fact]
	public async Task UpdateAsync_Succeeds()
	{
		var project = new ProjectCreate
		{
			Name = "Test Project",
			Identifier = "test-project",
		};

		// Create
		var createdProject = await OpenProjectClient
			.Projects
			.CreateAsync(project, default);

		createdProject.Should().NotBeNull();

		// Update
		var updateProject = new ProjectUpdate
		{
			Name = "Test Project Updated",
			Identifier = "test-project-updated",
		};

		var updatedProject = await OpenProjectClient
			.Projects
			.UpdateAsync(createdProject.Id, updateProject, default);

		updatedProject.Should().NotBeNull();
		updatedProject.Name.Should().Be(updateProject.Name);

		// Delete
		await OpenProjectClient
			.Projects
			.DeleteAsync(updatedProject.Id, default);
	}

	[Fact]
	public async Task GetAvailableAssigneesAsync_Succeeds()
	{
		var items = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		foreach (var item in items.Embedded.Elements)
		{
			// Get
			var availableAssignees = await OpenProjectClient
				.Projects
				.GetAvailableAssigneesAsync(item.Id, default);

			availableAssignees.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task GetAvailableParentProjectsAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Projects
			.GetAvailableParentProjectsAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetWorkPackagesAsync_Succeeds()
	{
		var items = await OpenProjectClient
			.Projects
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
		items.Embedded.Elements.Should().NotBeNull();

		foreach (var item in items.Embedded.Elements)
		{
			// Get
			var workPackages = await OpenProjectClient
				.Projects
				.GetWorkPackagesAsync(item.Id, default);

			workPackages.Should().NotBeNull();
		}
	}
}
