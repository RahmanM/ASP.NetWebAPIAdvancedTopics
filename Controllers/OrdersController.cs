using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Routing;
using Asp.NetWebApiWithPaging.Models;

// This project contains:
// 1) Paging of the result
// 2) Hypermedia (creating next and previous links)
// 3) Caching using CasheCow
// CaschCow testing process -> http://www.c-sharpcorner.com/article/apply-caching-in-webapi-using-cachecow/

namespace Asp.NetWebApiWithPaging.Controllers
{
    public class OrdersController : ApiController
    {


        /// <summary>
        /// Return top 20 orders from the system
        /// NOTE: this function supports paging the default is first page. However, supplying
        /// a page number will try to fetch the records from the next pages.
        /// </summary>
        /// <param name="page">page of the record to be fetched</param>
        [ResponseType(typeof(IEnumerable<OrderWrapper>))]
        public IHttpActionResult Get(int page = 0)
        {
            var orderWrapper = new OrderWrapper();

            try
            {
                // I queryable result
                var result = OrderHelper.GetOrders();

                var pagedResult =
                    PagingHelper<OrderModel>.PagedResult(page, result);

                // create the wrapper for total pages and total records
                orderWrapper.Orders = pagedResult;
                orderWrapper.TotalRecords = PagingHelper<OrderModel>.TotalRecords; ;
                orderWrapper.TotalPages = PagingHelper<OrderModel>.TotalPages();

                // Make the URL helpers
                var urlHelper = new UrlHelper(Request);
                orderWrapper.PreviousLink = page > 0 ? urlHelper.Link("DefaultApi", new { page = page - 1 }) : "";
                orderWrapper.NextLink = page < orderWrapper.TotalPages ? urlHelper.Link("DefaultApi", new { page = page + 1 }) : "";

                return Ok(orderWrapper);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

    }
}
