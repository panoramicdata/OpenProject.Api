namespace OpenProject.Api.Test.Tests;

public class MyPreferencesTests(
ITestOutputHelper testOutputHelper,
Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		var items = await OpenProjectClient
			.MyPreferences
			.GetAsync(default);

		items.Should().NotBeNull();
	}
}
