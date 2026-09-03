namespace OpenProject.Api.Test.Tests;

public class NotificationTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.Notifications.GetAllAsync);

	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Notifications.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Notifications.GetAsync(element.Id, cancellationToken));
}
