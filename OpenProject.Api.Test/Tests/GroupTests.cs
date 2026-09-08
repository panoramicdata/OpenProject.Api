using OpenProject.Api.Data.Models.Create;
using Refit;

namespace OpenProject.Api.Test.Tests;

public class GroupTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.Groups.GetAllAsync);

	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Groups.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Groups.GetAsync(element.Id, cancellationToken));

	[Fact]
	public Task CreateAsync_Succeeds()
		=> CreateThenDeleteAsync("Test Group - 1");

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		var deleteResponse = await CreateThenDeleteAsync("Test Group - 2");

		deleteResponse.Should().NotBeNull();
		deleteResponse.IsSuccessStatusCode.Should().BeTrue();
	}

	// The two tests use distinct names so that a leftover group from one cannot collide with the other.
	private Task<IApiResponse> CreateThenDeleteAsync(string name)
		=> AssertCreateThenDeleteAsync(
			cancellationToken => OpenProjectClient.Groups.CreateAsync(
				new GroupCreate { Name = name },
				cancellationToken),
			(created, cancellationToken) => OpenProjectClient.Groups.DeleteAsync(created.Id, cancellationToken),
			created => created.Name.Should().Be(name));
}
