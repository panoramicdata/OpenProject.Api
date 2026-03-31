using OpenProject.Api.Data.CustomLinks;
using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Enums;

namespace OpenProject.Api.Test.Tests;

public class WorkPackageTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkPackages
			.GetAllAsync(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.WorkPackages
				.GetAsync(item.Id, CancellationToken);
			refetchedItem.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task CreateAsync_Succeeds()
	{
		var dataToSend = new WorkPackageCreate
		{
			Links = new WorkPackageCreateLinks
			{
				Project = new HrefItem { Href = "/api/v3/projects/1" },
				Type = new HrefItem { Href = "/api/v3/types/1" },
			},
			Subject = "Test Work Package",
			Description = new()
			{
				Format = Format.Markdown,
				Raw = "This is a test work package",
				Html = string.Empty,
			},
		};

		var item = await OpenProjectClient
			.WorkPackages
			.CreateAsync(dataToSend, CancellationToken);

		item.Should().NotBeNull();
		item.ItemType.Should().Be("WorkPackage");

		// Delete
		await OpenProjectClient
			.WorkPackages
			.DeleteAsync(item.Id, CancellationToken);
	}

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		// Create
		var dataToSend = new WorkPackageCreate
		{
			Links = new WorkPackageCreateLinks
			{
				Project = new HrefItem { Href = "/api/v3/projects/1" },
				Type = new HrefItem { Href = "/api/v3/types/1" }
			},
			Subject = "Test Work Package"
		};
		var item = await OpenProjectClient
			.WorkPackages
			.CreateAsync(dataToSend, CancellationToken);

		item.Should().NotBeNull();
		item.ItemType.Should().Be("WorkPackage");

		// Delete
		await OpenProjectClient
			.WorkPackages
			.DeleteAsync(item.Id, CancellationToken);
	}
}
