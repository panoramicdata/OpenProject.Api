using OpenProject.Api.Data.Models.Create;
using Refit;

namespace OpenProject.Api.Test.Tests;

public class NewsTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
{
	private const string TestNewsTitle = "Test News";

	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllAsync(OpenProjectClient.News.GetAllAsync);

	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(
			OpenProjectClient.News.GetAllAsync,
			(element, cancellationToken) => OpenProjectClient.News.GetAsync(element.Id, cancellationToken));

	[Fact]
	public Task CreateAsync_Succeeds()
		=> CreateThenDeleteAsync();

	[Fact]
	public async Task DeleteAsync_Succeeds()
	{
		var deleteResponse = await CreateThenDeleteAsync();

		deleteResponse.Should().NotBeNull();
		deleteResponse.IsSuccessStatusCode.Should().BeTrue();
	}

	private Task<IApiResponse> CreateThenDeleteAsync()
		=> AssertCreateThenDeleteAsync(
			cancellationToken => OpenProjectClient.News.CreateAsync(
				new NewsCreate
				{
					Title = TestNewsTitle,

					Links = new()
					{
						Project = new()
						{
							Href = "/api/v3/projects/1"
						}
					}
				},
				cancellationToken),
			(created, cancellationToken) => OpenProjectClient.News.DeleteAsync(created.Id, cancellationToken),
			created => created.Title.Should().Be(TestNewsTitle));
}
