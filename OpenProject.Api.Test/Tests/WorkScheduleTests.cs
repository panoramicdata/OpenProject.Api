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
			.GetAllDays(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetDayAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkSchedules
			.GetAllDays(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch
		foreach (var item in items.Embedded.Elements)
		{
			var date = $"{item.Date:yyyy-MM-dd}";
			var day = await OpenProjectClient
				.WorkSchedules
				.GetDay(date, CancellationToken);

			day.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task GetAllNonWorkingDaysAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkSchedules
			.GetAllNonWorkingDays(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetNonWorkingDayAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkSchedules
			.GetAllNonWorkingDays(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch
		foreach (var item in items.Embedded.Elements)
		{
			var date = $"{item.Date:yyyy-MM-dd}";

			var day = await OpenProjectClient
				.WorkSchedules
				.GetDay(date, CancellationToken);
			day.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task GetAllWorkingDaysAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkSchedules
			.GetAllWeekDays(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetWorkingDayAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.WorkSchedules
			.GetAllWeekDays(CancellationToken);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch
		foreach (var item in items.Embedded.Elements)
		{
			var day = await OpenProjectClient
				.WorkSchedules
				.GetWeekDay(item.Day, CancellationToken);
			day.Should().NotBeNull();
		}
	}
}
