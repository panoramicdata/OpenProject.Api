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
			.GetAllAsync(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Groups
			.GetAllAsync(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.Groups
				.GetAsync(item.Id, CancellationToken);
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
			.CreateAsync(newGroup, CancellationToken);

		response.Should().NotBeNull();
		response.Name.Should().Be(newGroup.Name);

		// Delete
		await OpenProjectClient
			.Groups
			.DeleteAsync(response.Id, CancellationToken);
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
			.CreateAsync(newGroup, CancellationToken);

		response.Should().NotBeNull();
		response.Name.Should().Be(newGroup.Name);

		// Delete
		var deleteResponse = await OpenProjectClient
			.Groups
			.DeleteAsync(response.Id, CancellationToken);

		deleteResponse.Should().NotBeNull();
		deleteResponse.IsSuccessStatusCode.Should().BeTrue();
	}
}