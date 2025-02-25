namespace OpenProject.Api;

/// <summary>
/// API client is mainly responsible for making the HTTP call to the API backend.
/// </summary>
public class OpenProjectClient : IDisposable
{
	/// <summary>
	/// Constructor
	/// </summary>
	/// <param name="options">OpenProject Client options</param>
	public OpenProjectClient(OpenProjectClientOptions options)
		: this(new HttpClient(new AuthenticatedHttpClientHandler(options))
		{
			BaseAddress = new Uri(options.Uri, new Uri("/api/v3", UriKind.Relative))
		})
	{
		_shouldDisposeHttpClient = true;
	}

	public OpenProjectClient(HttpClient client)
	{
		_httpClient = client;
		_refitSettings = new RefitSettings
		{
			//UrlParameterFormatter = new OpenProjectUrlParameterFormatter(),
		};

		Actions = RefitFor(Actions!);
		Grids = RefitFor(Grids!);
		News = RefitFor(News!);
		Principals = RefitFor(Principals!);
		Projects = RefitFor(Projects!);
		ProjectCategories = RefitFor(ProjectCategories!);
		ProjectStatuses = RefitFor(ProjectStatuses!);
		Users = RefitFor(Users!);
		UserGroups = RefitFor(UserGroups!);
		UserGroupMemberships = RefitFor(UserGroupMemberships!);
		WorkPackages = RefitFor(WorkPackages!);
		WorkPackageTypes = RefitFor(WorkPackageTypes!);
	}

	private T RefitFor<T>(T _)
		=> RestService.For<T>(_httpClient, _refitSettings);

	private readonly HttpClient _httpClient;
	private readonly RefitSettings _refitSettings;
	private readonly bool _shouldDisposeHttpClient;
	private bool _isDisposed;

	/// <inheritdoc />
	public IActions Actions { get; }

	/// <inheritdoc />
	public IGrids Grids { get; }

	/// <inheritdoc />
	public INews News { get; }

	/// <inheritdoc />
	public IPrincipals Principals { get; }

	/// <inheritdoc />
	public IProjects Projects { get; }

	public IProjectCategories ProjectCategories { get; }

	/// <inheritdoc />
	public IProjectStatuses ProjectStatuses { get; }

	/// <inheritdoc>/>
	public IUsers Users { get; }

	/// <inheritdoc>/>
	public IUserGroups UserGroups { get; }

	/// <inheritdoc>/>
	public IUserGroupMemberships UserGroupMemberships { get; }

	/// <inheritdoc />
	public IWorkPackages WorkPackages { get; }

	/// <inheritdoc />
	public IWorkPackageTypes WorkPackageTypes { get; }

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (disposing)
			{
				if (_shouldDisposeHttpClient)
				{
					_httpClient.Dispose();
				}
			}

			_isDisposed = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
