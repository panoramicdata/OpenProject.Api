namespace OpenProject.Api.Test.Tests;

public class RootTests(
ITestOutputHelper testOutputHelper,
Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetApiInformationAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Root
			.GetApiInformationAsync(default);

		items.Should().NotBeNull();
	}
}
