namespace OpenProject.Api.Test.Tests;

public class MembershipTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		var items = await OpenProjectClient
			.Memberships
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		var items = await OpenProjectClient
			.Memberships
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		foreach (var item in items.Embedded.Elements)
		{
			// Get
			var itemRefetch = await OpenProjectClient
				.Memberships
				.GetAsync(item.Id, default);

			itemRefetch.Should().NotBeNull();
		}
	}
}