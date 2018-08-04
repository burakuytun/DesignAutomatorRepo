using System.Collections.Generic;

namespace CrossCutting.Utils.PagedList
{
	public class PagedListParameters
	{
		public IList<Order> Orders { get; set; } = new List<Order>();

		public Page Page { get; set; } = new Page();
	}
}
