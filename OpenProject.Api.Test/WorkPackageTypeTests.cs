namespace OpenProject.Api.Test;

public class WorkPackageTypeTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var workPackageTypes = await OpenProjectClient
			.WorkPackageTypes
			.GetAllAsync(default);

		workPackageTypes.Should().NotBeNull();
		workPackageTypes.Embedded.Should().NotBeNull();
	}
}
