using Refit;

namespace OpenProject.Api.Test;

/// <summary>
/// The four tests shared by every endpoint that lists, re-fetches, creates and deletes.
/// They are defined once here rather than copied into each endpoint's test class; a derived
/// class supplies only the calls that differ.
/// </summary>
/// <typeparam name="TElement">The element type the endpoint lists.</typeparam>
/// <typeparam name="TGetResponse">What re-fetching a single element returns.</typeparam>
public abstract class CrudTestBase<TElement, TGetResponse>(
	ITestOutputHelper testOutputHelper,
	Fixture fixture) : TestBase(testOutputHelper, fixture)
	where TElement : ItemBase
{
	[Fact]
	public Task GetAllAsync_Succeeds()
		=> AssertGetAllAsync(GetAllAsync);

	[Fact]
	public Task GetAsync_Succeeds()
		=> AssertGetAllThenGetEachAsync(GetAllAsync, GetAsync);

	[Fact]
	public Task CreateAsync_Succeeds()
		=> CreateThenDeleteAsync();

	[Fact]
	public async Task DeleteAsync_Succeeds()
		=> AssertDeleteSucceeded(await CreateThenDeleteAsync());

	/// <summary>
	/// Lists the endpoint's resources.
	/// </summary>
	protected abstract Task<OpenProjectItemSet<TElement>> GetAllAsync(CancellationToken cancellationToken);

	/// <summary>
	/// Re-fetches a single listed element.
	/// </summary>
	protected abstract Task<TGetResponse> GetAsync(TElement element, CancellationToken cancellationToken);

	/// <summary>
	/// Creates a resource, asserts the create response, then deletes it and returns the
	/// delete response.
	/// </summary>
	protected abstract Task<IApiResponse> CreateThenDeleteAsync();
}
