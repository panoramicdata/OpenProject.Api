namespace OpenProject.Api.Test.Tests;

public class TypeTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var workPackageTypes = await OpenProjectClient
			.Types
			.GetAllAsync(default);

		workPackageTypes.Should().NotBeNull();
		workPackageTypes.Embedded.Should().NotBeNull();
	}
}
