namespace Misc.Shared.Models
{
    public record NavItem(string Title, string Key, string? Href = null, string? Icon = null, IEnumerable<NavItem>? Children = null);
}