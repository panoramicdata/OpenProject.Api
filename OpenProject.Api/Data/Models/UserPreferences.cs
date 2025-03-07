using System.Text.Json.Serialization;

namespace OpenProject.Api.Data.Models;
/// <summary>
/// The Default preferences section covers default user settings.
/// Here, you can specify the default language for new users as well as the default time zone.
/// The default language is displayed for users when they first sign into OpenProject.They can then choose a different language
/// <para>See <a href='https://www.openproject.org/docs/system-admin-guide/users-permissions/settings/'/></para>
/// </summary>
public class UserPreferences : ItemBase
{
	/// <summary>
	/// Whether to hide popups (e.g. success messages) after 5 seconds	
	/// </summary>
	public bool AutoHidePopups { get; set; }

	/// <summary>
	/// The settings for the notifications to be received by the user	
	/// </summary>
	public required object Notifications { get; set; }

	/// <summary>
	/// Current selected time zone	
	/// </summary>
	public required string TimeZone { get; set; }

	/// <summary>
	/// Sort comments in descending order	
	/// </summary>
	[JsonPropertyName("commentSortDescending")]
	public bool SortCommentsByDescending { get; set; }

	/// <summary>
	/// Issue warning when leaving a page with unsaved text	
	/// </summary>
	public bool WarnOnLeavingUnsaved { get; set; }
}
