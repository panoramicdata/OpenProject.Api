using OpenProject.Api.Data.Models;
using OpenProject.Api.Data.Models.Create;
using Refit;

namespace OpenProject.Api.Test.Tests;

public class NewsTests(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : CrudTestBase<News, OpenProjectItemSet<News>>(testOutputHelper, fixture)
{
	private const string TestNewsTitle = "Test News";

	protected override Task<OpenProjectItemSet<News>> GetAllAsync(CancellationToken cancellationToken)
		=> OpenProjectClient.News.GetAllAsync(cancellationToken);

	protected override Task<OpenProjectItemSet<News>> GetAsync(News element, CancellationToken cancellationToken)
		=> OpenProjectClient.News.GetAsync(element.Id, cancellationToken);

	protected override Task<IApiResponse> CreateThenDeleteAsync()
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
