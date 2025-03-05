using OpenProject.Api.Data.CustomLinks;
using OpenProject.Api.Data.Models.Create;

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
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.WorkPackages
				.GetAsync(item.Id, default);
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
				Type = new HrefItem { Href = "/api/v3/types/1" }
			},
			Subject = "Test Work Package"
		};

		var item = await OpenProjectClient
			.WorkPackages
			.CreateAsync(dataToSend, default);

		item.Should().NotBeNull();
		item.ItemType.Should().Be("WorkPackage");
	}
}
