using OpenProject.Api.Data.Models.Create;

namespace OpenProject.Api.Test.Tests;
public class QueriesTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Queries
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Queries
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.Queries
				.GetAsync(item.Id, default);
			refetchedItem.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task CreateAsync_Succeeds()
	{
		var query = new QueryCreate
		{
			Name = "Test Query"
		};

		// Create
		var createResponse = await OpenProjectClient
			.Queries.CreateAsync(query, default);

		createResponse.Should().NotBeNull();
		createResponse.Name.Should().Be(query.Name);

		// Delete
		await OpenProjectClient
			.Queries.DeleteAsync(createResponse.Id, default);
	}

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		var query = new QueryCreate
		{
			Name = "Test Query"
		};

		// Create
		var createResponse = await OpenProjectClient
			.Queries.CreateAsync(query, default);

		createResponse.Should().NotBeNull();
		createResponse.Name.Should().Be(query.Name);

		// Delete
		var deleteResponse = await OpenProjectClient
			.Queries.DeleteAsync(createResponse.Id, default);

		deleteResponse.Should().NotBeNull();
		deleteResponse.IsSuccessStatusCode.Should().BeTrue();
	}
}
