using OpenProject.Api.Data.Models.Create;

namespace OpenProject.Api.Test.Tests;
public class NewsTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.News
			.GetAllAsync(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.News
			.GetAllAsync(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.News
				.GetAsync(item.Id, CancellationToken);
			refetchedItem.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task CreateAsync_Succeeds()
	{
		var newNews = new NewsCreate
		{
			Title = "Test News",

			Links = new()
			{
				Project = new()
				{
					Href = "/api/v3/projects/1"
				}
			}
		};

		// Create
		var item = await OpenProjectClient
			.News
			.CreateAsync(newNews, CancellationToken);

		item.Should().NotBeNull();
		item.Title.Should().Be(newNews.Title);

		// Delete
		await OpenProjectClient
			.News
			.DeleteAsync(item.Id, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		var newNews = new NewsCreate
		{
			Title = "Test News",

			Links = new()
			{
				Project = new()
				{
					Href = "/api/v3/projects/1"
				}
			}
		};

		// Create
		var item = await OpenProjectClient
			.News
			.CreateAsync(newNews, CancellationToken);
		item.Should().NotBeNull();
		item.Title.Should().Be(newNews.Title);

		// Delete
		var response = await OpenProjectClient
			.News
			.DeleteAsync(item.Id, CancellationToken);

		response.Should().NotBeNull();
		response.IsSuccessStatusCode.Should().BeTrue();
	}
}
