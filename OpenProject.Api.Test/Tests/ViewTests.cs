namespace OpenProject.Api.Test.Tests;

public class ViewTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Views
			.GetAllAsync(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.Views
				.GetAsync(item.Id, CancellationToken);
			refetchedItem.Should().NotBeNull();
		}
	}
}
