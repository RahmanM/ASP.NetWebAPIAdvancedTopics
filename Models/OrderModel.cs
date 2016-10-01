using System;
using System.Collections.Generic;

namespace Asp.NetWebApiWithPaging.Models
{

    /// <summary>
    /// Wrapper around the orders with information about the total records, total pages
    /// and next and previous hyper links to navigate to pages.
    /// </summary>
    public class OrderWrapper
    {

        /// <summary>
        /// Total pages of the records
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Total records
        /// </summary>
        public decimal TotalRecords { get; set; }

        /// <summary>
        /// Link on how to access the previous order
        /// </summary>
        public string PreviousLink { get; set; }

        /// <summary>
        /// Link on how to access the next order
        /// </summary>
        public string NextLink { get; set; }

        /// <summary>
        /// A collection of the orders
        /// </summary>
        public List<OrderModel> Orders { get; set; }

    }

    /// <summary>
    /// A model representing an order and its lines.
    /// </summary>
    public class OrderModel 
    {
        /// <summary>
        /// Order identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Total order amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Date order was issued
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// List of order lines for this order
        /// </summary>
        public List<OrderLineModel> Lines { get; set; }

        public OrderModel()
        {
            Lines = new List<OrderLineModel>();
        }
    }

    /// <summary>
    /// Details of an order line
    /// </summary>
    public class OrderLineModel
    {
        /// <summary>
        /// order line identifier
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// order line amount
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// product sold for this line
        /// </summary>
        public string Product { get; set; }
    }
}