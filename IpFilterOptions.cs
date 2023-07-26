namespace Salt.IpFilter;

using System.Net;

/// <summary>
/// Filtration settings
/// </summary>
public class IpFilterOptions
{
    /// <summary>
    /// What to do
    /// </summary>
    public IpFilterPolicy Policy { get; set; }
    /// <summary>
    /// IPs for filtering
    /// </summary>
    public IPAddress[] Addresses { get; set; }
}
