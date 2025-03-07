using OpenProject.Api.Data.Models.Create;

namespace OpenProject.Api.Test.Tests;

public class GroupTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Groups
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Groups
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.Groups
				.GetAsync(item.Id, default);
			refetchedItem.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task CreateAsync_Succeeds()
	{
		// Get
		var newGroup = new GroupCreate
		{
			Name = "Test Group - 1"
		};

		var response = await OpenProjectClient
			.Groups
			.CreateAsync(newGroup, default);

		response.Should().NotBeNull();
		response.Name.Should().Be(newGroup.Name);

		// Delete
		var deleteResponse = await OpenProjectClient
			.Groups
			.DeleteAsync(response.Id, default);
	}

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		// Get
		var newGroup = new GroupCreate
		{
			Name = "Test Group - 2"
		};

		var response = await OpenProjectClient
			.Groups
			.CreateAsync(newGroup, default);

		response.Should().NotBeNull();
		response.Name.Should().Be(newGroup.Name);

		// Delete
		var deleteResponse = await OpenProjectClient
			.Groups
			.DeleteAsync(response.Id, default);

		deleteResponse.Should().NotBeNull();
		deleteResponse.IsSuccessStatusCode.Should().BeTrue();
	}
}