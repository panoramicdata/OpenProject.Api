namespace OpenProject.Api.Test.Tests;

public class UserGroupTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.UserGroups
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.UserGroups
				.GetAsync(item.Id, default);
			refetchedItem.Should().NotBeNull();
		}
	}
}