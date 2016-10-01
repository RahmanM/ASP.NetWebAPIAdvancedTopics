using System;
using System.Collections.Generic;
using System.Linq;

namespace Asp.NetWebApiWithPaging.Controllers
{
    public class PagingHelper<TModel>
    {
        /// <summary>
        /// Records per page
        /// </summary>
        public static int PAGE_SIZE = 20;

        /// <summary>
        /// Total records of the data
        /// </summary>
        public static int TotalRecords { get; set; }

        /// <summary>
        /// Total pages of the data based on size
        /// </summary>
        public static int TotalPages()
        {
            return TotalRecords  / PAGE_SIZE;
        }

        /// <summary>
        /// Returns a paged result based on page size and total pages in the set
        /// </summary>
        /// <param name="page">Page of the data to return</param>
        /// <param name="result">Data</param>
        public static List<TModel> PagedResult(int page, IQueryable<TModel> result)
        {
            if (result == null)
            {
                throw new ArgumentNullException("result");
            }

            TotalRecords = result.Count();

            // Make the result page able
            var pagedResult = result
                .Skip(page * PAGE_SIZE)
                .Take(PAGE_SIZE)
                .ToList();
            
            return pagedResult;
        }
    }
}