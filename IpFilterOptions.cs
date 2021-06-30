using System.Net;

namespace Salt.IpFilter
{
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
}