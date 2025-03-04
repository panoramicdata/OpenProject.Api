namespace OpenProject.Api.Test.Tests;

public class HelpTextTests(
ITestOutputHelper testOutputHelper,
Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.HelpTexts
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.HelpTexts
				.GetAsync(item.Id, default);
			refetchedItem.Should().NotBeNull();
		}
	}
}
