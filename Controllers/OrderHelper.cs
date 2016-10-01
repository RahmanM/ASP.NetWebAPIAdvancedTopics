using System;
using System.Collections.Generic;
using System.Linq;
using Asp.NetWebApiWithPaging.Models;

namespace Asp.NetWebApiWithPaging.Controllers
{
    public class OrderHelper
    {
        public static IQueryable<OrderModel> GetOrders()
        {
            var list = new List<OrderModel>();

            for (int i = 0; i < 500; i++)
            {
                var order = new OrderModel()
                {
                    Date = DateTime.Now.AddDays(i),
                    Id = i,
                    Amount = i
                };

                for (int l = 0; l < 2; l++)
                {
                    var line = new OrderLineModel
                    {
                        Amount = l,
                        Id = l,
                        Product = "Product " + l
                    };

                    order.Lines.Add(line);
                }

                list.Add(order);
            }

            return list.AsQueryable();
        }
    }
}