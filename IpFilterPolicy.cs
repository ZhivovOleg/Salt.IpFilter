namespace Salt.IpFilter;

/// <summary>
/// What filter have to do
/// </summary>
public enum IpFilterPolicy
{
    /// <summary>
    /// Do nothing, just eat memory :)
    /// </summary>
    NOTHING = 0,
    /// <summary>
    /// Addresses in collection will be blocked, all others allowed
    /// </summary>
    DENY = 1,
    /// <summary>
    /// Allow only addresse in collection, all others will be blocked
    /// </summary>
    ALLOW = 2
}