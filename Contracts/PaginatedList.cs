using System;
namespace digitalwedding.Contracts
{
	public class PaginatedList<T> : List<T>
	{
		public int PageSize { get; private set; }
		public int PageIndex { get; private set; }
		public int TotalPages { get; private set; }
		public int TotalRecords { get; private set; }
		public PaginatedList(List<T> items, int pageIndex, int pageSize, int totalRecords)
		{
			PageIndex = pageIndex;
			PageSize = 0;
			TotalRecords = totalRecords;
			TotalPages = totalRecords > 0 ? (int)Math.Ceiling(totalRecords / (double)pageSize) : 0;

			if(items.Count > 0)
			{
                PageSize = pageSize;
                AddRange(items);

				if(items.Count < pageSize)
				{
					PageSize = items.Count;
                }
			}
		}
	}
}

