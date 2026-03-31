namespace OpenProject.Api.Test.Tests;

public class RolesTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Roles
			.GetAllAsync(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.Roles
				.GetAsync(item.Id, CancellationToken);
			refetchedItem.Should().NotBeNull();
		}
	}
}
