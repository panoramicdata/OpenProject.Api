namespace OpenProject.Api.Test;

public class UserGroupTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var userGroups = await OpenProjectClient
			.UserGroups
			.GetAllAsync(default);

		userGroups.Should().NotBeNull();
		userGroups.Embedded.Should().NotBeNull();

		// Re-fetch each
		foreach (var userGroup in userGroups.Embedded.Elements)
		{
			var userGroupRefetch = await OpenProjectClient
				.UserGroups
				.GetAsync(userGroup.Id, default);
			userGroupRefetch.Should().NotBeNull();
		}
	}
}