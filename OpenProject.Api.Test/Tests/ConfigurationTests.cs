namespace OpenProject.Api.Test.Tests;

public class ConfigurationTests(
ITestOutputHelper testOutputHelper,
Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var config = await OpenProjectClient
			.Configuration
			.GetAsync(default);

		config.Should().NotBeNull();

	}
}
