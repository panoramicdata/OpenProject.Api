namespace OpenProject.Api.Test.Tests;

public class WorkScheduleTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllDaysAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkSchedules
			.GetAllDays(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAllNonWorkingDaysAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkSchedules
			.GetAllNonWorkingDays(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAllWorkingDaysAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkSchedules
			.GetAllWeekDays(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}
}
