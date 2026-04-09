namespace OpenProject.Api.Enums;

/// <summary>
/// The current activation status of the User
/// </summary>
public enum UserStatus
{
	/// <summary>
	/// The user account is active and can log in.
	/// </summary>
	Active,

	/// <summary>
	/// The user has registered but has not yet been activated.
	/// </summary>
	Registered,

	/// <summary>
	/// The user account has been locked by an administrator.
	/// </summary>
	Locked,

	/// <summary>
	/// The user has been invited but has not yet accepted.
	/// </summary>
	Invited
}
