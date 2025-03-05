namespace OpenProject.Api.Test.Tests;

public class VersionTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Versions
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.Versions
				.GetAsync(item.Id, default);
			refetchedItem.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task GetAvailableProjectsAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Versions
			.GetAvailableProjectsAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}
}
