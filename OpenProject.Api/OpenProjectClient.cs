using OpenProject.Api.Interfaces.Controllers;

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

	/// <summary>
	/// Initializes a new instance of the <see cref="OpenProjectClient"/> class using a pre-configured <see cref="HttpClient"/>.
	/// </summary>
	/// <param name="client">The HTTP client to use for API requests.</param>
	public OpenProjectClient(HttpClient client)
	{
		_httpClient = client;
		_refitSettings = new RefitSettings
		{
			//UrlParameterFormatter = new OpenProjectUrlParameterFormatter(),
		};

		Actions = RefitFor<IActions>();
		Categories = RefitFor<ICategories>();
		Configuration = RefitFor<IConfiguration>();
		Documents = RefitFor<IDocuments>();
		Grids = RefitFor<IGrids>();
		HelpTexts = RefitFor<IHelpTexts>();
		News = RefitFor<INews>();
		MyPreferences = RefitFor<IMyPreferences>();
		Notifications = RefitFor<INotifications>();
		Principals = RefitFor<IPrincipals>();
		Projects = RefitFor<IProjects>();
		Roles = RefitFor<IRoles>();
		Root = RefitFor<IRoot>();
		Relations = RefitFor<IRelations>();
		Statuses = RefitFor<IStatuses>();
		TimeEntries = RefitFor<ITimeEntries>();
		Queries = RefitFor<IQueries>();
		Users = RefitFor<IUsers>();
		Groups = RefitFor<IGroups>();
		Memberships = RefitFor<IMemberships>();
		Versions = RefitFor<IVersions>();
		Views = RefitFor<IViews>();
		WorkPackages = RefitFor<IWorkPackages>();
		WorkSchedules = RefitFor<IWorkSchedules>();
		Types = RefitFor<ITypes>();
	}

	private T RefitFor<T>()
		=> RestService.For<T>(_httpClient, _refitSettings);

	private readonly HttpClient _httpClient;
	private readonly RefitSettings _refitSettings;
	private readonly bool _shouldDisposeHttpClient;
	private bool _isDisposed;

	/// <inheritdoc />
	public IActions Actions { get; }

	/// <inheritdoc />
	public IConfiguration Configuration { get; }

	/// <inheritdoc />
	public IDocuments Documents { get; }

	/// <inheritdoc />
	public IGrids Grids { get; }

	/// <inheritdoc />
	public IHelpTexts HelpTexts { get; }

	/// <inheritdoc />
	public IMyPreferences MyPreferences { get; }

	/// <inheritdoc />
	public INews News { get; }

	/// <inheritdoc />
	public IPrincipals Principals { get; }

	/// <inheritdoc />
	public IProjects Projects { get; }

	/// <inheritdoc />
	public ICategories Categories { get; }

	/// <inheritdoc />
	public INotifications Notifications { get; }

	/// <inheritdoc />
	public IRoles Roles { get; }

	/// <inheritdoc />
	public IRoot Root { get; }

	/// <inheritdoc />
	public IRelations Relations { get; }

	/// <inheritdoc />
	public IStatuses Statuses { get; }

	/// <inheritdoc />
	public ITimeEntries TimeEntries { get; }

	/// <inheritdoc />
	public IQueries Queries { get; }

	/// <inheritdoc />
	public IUsers Users { get; }

	/// <inheritdoc />
	public IGroups Groups { get; }

	/// <inheritdoc />
	public IMemberships Memberships { get; }

	/// <inheritdoc />
	public IVersions Versions { get; }

	/// <inheritdoc />
	public IViews Views { get; }

	/// <inheritdoc />
	public IWorkPackages WorkPackages { get; }

	/// <inheritdoc />
	public IWorkSchedules WorkSchedules { get; }

	/// <inheritdoc />
	public ITypes Types { get; }

	/// <summary>
	/// Releases the unmanaged resources used by the <see cref="OpenProjectClient"/> and optionally releases the managed resources.
	/// </summary>
	/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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

	/// <inheritdoc />
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
