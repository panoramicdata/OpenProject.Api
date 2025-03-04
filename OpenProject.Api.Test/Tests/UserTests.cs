using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Data.Models.Update;
using OpenProject.Api.Enums;

namespace OpenProject.Api.Test.Tests;

public class UserTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public async Task GetAllAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Users
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();
	}

	[Fact]
	public async Task GetAsync_Succeeds()
	{
		// Get
		var items = await OpenProjectClient
			.Users
			.GetAllAsync(default);

		items.Should().NotBeNull();
		items.Embedded.Should().NotBeNull();

		items.Embedded.Elements.Should().NotBeNull();

		// Re-fetch each
		foreach (var item in items.Embedded.Elements)
		{
			var refetchedItem = await OpenProjectClient
				.Users
				.GetAsync(item.Id, default);
			refetchedItem.Should().NotBeNull();
		}
	}

	[Fact]
	public async Task PostAsync_Succeeds()
	{
		var newUser = new UserCreate
		{
			Login = "j.sheppard",
			Password = "idestroyedsouvereign",
			FirstName = "John",
			LastName = "Sheppard",
			Email = "jshep@mail.com",
			IsAdmin = false,
			Status = UserStatus.Active,
			Language = "en"
		};

		// Create
		var item = await OpenProjectClient
			.Users
			.PostAsync(newUser, default);

		item.Should().NotBeNull();

		// Delete
		var result = await OpenProjectClient
			.Users
			.DeleteAsync(item.Id, default);

		result.Should().NotBeNull();
		result.Should().Contain("null");
	}

	[Fact]
	public async Task PatchAsync_Succeeds()
	{
		var newUser = new UserCreate
		{
			Login = "e.sheep",
			Password = "ihaveapassword",
			FirstName = "Elliot",
			LastName = "Sheep",
			Email = "eshep@mail.com",
			IsAdmin = false,
			Status = UserStatus.Active,
			Language = "en"
		};

		// Create
		var item = await OpenProjectClient
			.Users
			.PostAsync(newUser, default);

		// Update
		var updatedItem = await OpenProjectClient
			.Users
			.PatchAsync(item.Id, new UserUpdate
			{
				Login = "e.sheep",
				Password = "ihaveapassword",
				FirstName = "Elliot - EDITED",
				LastName = "Sheep",
				Email = "eshep@mail.com",
				IsAdmin = false,
				Status = UserStatus.Active,
				Language = "en"
			}, default);

		updatedItem.Should().NotBeNull();
		updatedItem.FirstName.Should().Be("Elliot - EDITED");

		// Delete
		var result = await OpenProjectClient
			.Users
			.DeleteAsync(item.Id, default);

		result.Should().NotBeNull();
		result.Should().Contain("null");

	}

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		var newUser = new UserCreate
		{
			Login = "p.shrub",
			Password = "bigpasswordnotsecure",
			FirstName = "Paul",
			LastName = "Shrub",
			Email = "pshrub@mail.com",
			IsAdmin = false,
			Status = UserStatus.Active,
			Language = "en"
		};

		// Create
		var item = await OpenProjectClient
			.Users
			.PostAsync(newUser, default);

		item.Should().NotBeNull();

		// Delete
		var result = await OpenProjectClient
			.Users
			.DeleteAsync(item.Id, default);

		result.Should().NotBeNull();
		result.Should().Contain("null");
	}
}
