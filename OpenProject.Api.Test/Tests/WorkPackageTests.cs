using OpenProject.Api.Data.CustomLinks;
using OpenProject.Api.Data.Models.Create;
using OpenProject.Api.Enums;
using Refit;

namespace OpenProject.Api.Test.Tests;

public class WorkPackageTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.WorkPackages.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.WorkPackages.GetAsync(element.Id, cancellationToken));

	[Fact]
	public Task CreateAsync_Succeeds()
		=> CreateThenDeleteAsync(new()
		{
			Format = Format.Markdown,
			Raw = "This is a test work package",
			Html = string.Empty,
		});

	[Fact]
	public Task DeleteAsync_Succeeds()
		=> CreateThenDeleteAsync(description: null);

	private Task<IApiResponse> CreateThenDeleteAsync(Formattable? description)
		=> AssertCreateThenDeleteAsync(
			cancellationToken => OpenProjectClient.WorkPackages.CreateAsync(
				new WorkPackageCreate
				{
					Links = new WorkPackageCreateLinks
					{
						Project = new HrefItem { Href = "/api/v3/projects/1" },
						Type = new HrefItem { Href = "/api/v3/types/1" },
					},
					Subject = "Test Work Package",
					Description = description,
				},
				cancellationToken),
			(created, cancellationToken) => OpenProjectClient.WorkPackages.DeleteAsync(created.Id, cancellationToken),
			created => created.ItemType.Should().Be("WorkPackage"));
}
