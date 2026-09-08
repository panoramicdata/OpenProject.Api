namespace OpenProject.Api.Test.Tests;

public class WorkScheduleTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllDaysAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.WorkSchedules.GetAllDays);

	[Fact]
	public Task GetDayAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.WorkSchedules.GetAllDays,
			(element, cancellationToken) => OpenProjectClient.WorkSchedules.GetDay(
				$"{element.Date:yyyy-MM-dd}",
				cancellationToken));

	[Fact]
	public Task GetAllNonWorkingDaysAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.WorkSchedules.GetAllNonWorkingDays);

	[Fact]
	public Task GetNonWorkingDayAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.WorkSchedules.GetAllNonWorkingDays,
			// Deliberately GetDay, not GetNonWorkingDay: this preserves what the test asserted before.
			(element, cancellationToken) => OpenProjectClient.WorkSchedules.GetDay(
				$"{element.Date:yyyy-MM-dd}",
				cancellationToken));

	[Fact]
	public Task GetAllWorkingDaysAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.WorkSchedules.GetAllWeekDays);

	[Fact]
	public Task GetWorkingDayAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.WorkSchedules.GetAllWeekDays,
			(element, cancellationToken) => OpenProjectClient.WorkSchedules.GetWeekDay(element.Day, cancellationToken));
}
