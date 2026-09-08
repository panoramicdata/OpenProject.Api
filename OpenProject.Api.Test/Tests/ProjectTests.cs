using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Data.Models.Update;
using Refit;

namespace OpenProject.Api.Test.Tests;

public class ProjectTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.Projects.GetAllAsync);

	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Projects.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Projects.GetAsync(element.Id, cancellationToken));

	[Fact]
	public Task CreateAsync_Succeeds()
		=> CreateThenDeleteAsync();

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		var deleteResponse = await CreateThenDeleteAsync();

		deleteResponse.IsSuccessStatusCode.Should().BeTrue();
	}

	[Fact]
	public async Task UpdateAsync_Succeeds()
	{
		// Create
		var createdProject = await OpenProjectClient
			.Projects
			.CreateAsync(NewProject(), CancellationToken);

		createdProject.Should().NotBeNull();

		// Update
		var updateProject = new ProjectUpdate
		{
			Name = "Test Project Updated",
			Identifier = "test-project-updated",
		};

		var updatedProject = await OpenProjectClient
			.Projects
			.UpdateAsync(createdProject.Id, updateProject, CancellationToken);

		updatedProject.Should().NotBeNull();
		updatedProject.Name.Should().Be(updateProject.Name);

		// Delete
		await OpenProjectClient
			.Projects
			.DeleteAsync(updatedProject.Id, CancellationToken);
	}

	[Fact]
	public Task GetAvailableAssigneesAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Projects.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Projects.GetAvailableAssigneesAsync(
				element.Id,
				cancellationToken));

	[Fact]
	public Task GetAvailableParentProjectsAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.Projects.GetAvailableParentProjectsAsync);

	[Fact]
	public Task GetWorkPackagesAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Projects.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Projects.GetWorkPackagesAsync(
				element.Id,
				cancellationToken));

	private static ProjectCreate NewProject()
		=> new()
		{
			Name = "Test Project",
			Identifier = "test-project",
		};

	private Task<IApiResponse> CreateThenDeleteAsync()
		=> AssertCreateThenDeleteAsync(
			cancellationToken => OpenProjectClient.Projects.CreateAsync(NewProject(), cancellationToken),
			(created, cancellationToken) => OpenProjectClient.Projects.DeleteAsync(created.Id, cancellationToken));
}
