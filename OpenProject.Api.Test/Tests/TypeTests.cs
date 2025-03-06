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

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var workPackageType = await OpenProjectClient
			.Types
			.GetAllAsync(default);

		workPackageType.Should().NotBeNull();
		workPackageType.Embedded.Should().NotBeNull();
		workPackageType.Embedded.Elements.Should().NotBeNull();

		// Refetch
		foreach (var item in workPackageType.Embedded.Elements)
		{
			var response = await OpenProjectClient.
				Types.GetAsync(item.Id, default);

			response.Should().NotBeNull();
			response.Id.Should().Be(item.Id);
		}
	}
}
