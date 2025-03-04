namespace OpenProject.Api.Test.Tests;

public class DocumentTests(
ITestOutputHelper testOutputHelper,
Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Documents
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.Documents
				.GetAsync(item.Id, default);
			refetchedItem.Should().NotBeNull();
		}
	}
}
