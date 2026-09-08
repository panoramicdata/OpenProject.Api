using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Data.Models.Update;
using OpenProject.Api.Enums;

namespace OpenProject.Api.Test.Tests;

public class UserTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.Users.GetAllAsync);

	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.Users.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.Users.GetAsync(element.Id, cancellationToken));

	[Fact]
	public Task PostAsync_Succeeds()
		=> CreateThenDeleteAsync(
			NewUser("j.sheppard", "idestroyedsouvereign", "John", "Sheppard", "jshep@mail.com"));

	[Fact]
	public Task DeleteAsync_Succeeds()
		=> CreateThenDeleteAsync(
			NewUser("p.shrub", "bigpasswordnotsecure", "Paul", "Shrub", "pshrub@mail.com"));

	[Fact]
	public async Task PatchAsync_Succeeds()
	{
		var newUser = NewUser("e.sheep", "ihaveapassword", "Elliot", "Sheep", "eshep@mail.com");

		// Create
		var item = await OpenProjectClient
			.Users
			.PostAsync(newUser, CancellationToken);

		// Update
		var updatedItem = await OpenProjectClient
			.Users
			.PatchAsync(item.Id, new UserUpdate
			{
				Login = newUser.Login,
				Password = newUser.Password,
				FirstName = "Elliot - EDITED",
				LastName = newUser.LastName,
				Email = newUser.Email,
				IsAdmin = newUser.IsAdmin,
				Status = newUser.Status,
				Language = newUser.Language
			}, CancellationToken);

		updatedItem.Should().NotBeNull();
		updatedItem.FirstName.Should().Be("Elliot - EDITED");

		// Delete
		var result = await OpenProjectClient
			.Users
			.DeleteAsync(item.Id, CancellationToken);

		AssertDeleted(result);
	}

	// Each test uses a distinct login and e-mail so that a leftover user from one cannot collide
	// with another.
	private static UserCreate NewUser(
		string login,
		string password,
		string firstName,
		string lastName,
		string email)
		=> new()
		{
			Login = login,
			Password = password,
			FirstName = firstName,
			LastName = lastName,
			Email = email,
			IsAdmin = false,
			Status = UserStatus.Active,
			Language = "en"
		};

	private static void AssertDeleted(string result)
	{
		result.Should().NotBeNull();
		result.Should().Contain("null");
	}

	private async Task CreateThenDeleteAsync(UserCreate newUser)
	{
		var result = await AssertCreateThenDeleteAsync(
			cancellationToken => OpenProjectClient.Users.PostAsync(newUser, cancellationToken),
			(created, cancellationToken) => OpenProjectClient.Users.DeleteAsync(created.Id, cancellationToken));

		AssertDeleted(result);
	}
}
