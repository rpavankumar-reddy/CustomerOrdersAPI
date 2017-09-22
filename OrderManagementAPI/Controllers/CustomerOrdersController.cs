using Newtonsoft.Json.Linq;
using OrderManagementAPI.Custom;
using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace OrderManagementAPI.Controllers
{
    public class Singleton
    {
        private static ManageOrders instance;

        private Singleton() { }

        public static ManageOrders Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManageOrders();
                }
                return instance;
            }
        }
    }
    public class CustomerOrdersController : ApiController
    {
        private static ManageOrders manageOrders = Singleton.Instance;
        public HttpResponseMessage GetAllOrders()
        {
            var item = manageOrders.GetAllOrders();
            return new HttpResponseMessage()
            {
                Content = new StringContent(JArray.FromObject(item).ToString(), Encoding.UTF8, "application/json")
            };
        }

        public HttpResponseMessage GetCustomerOrder(int orderId)
        {
            var orderItems = manageOrders.GetCustomerOrders(orderId);
            if (orderItems == null)
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("Customer Order Not Found")
                };

            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent(JArray.FromObject(orderItems).ToString(), Encoding.UTF8, "application/json")
                };
            }
        }

        public IHttpActionResult PostCustomerOrder(JObject objData)
        {
            dynamic jsonData = objData;
            //dynamic jsonData = JObject.Parse(objData);
            //2.
            //JObject basketJson = jsonData.basket;
            var cusbasket = jsonData.ToObject<OrderItems>();
            var id = manageOrders.AddCustomerOrder(cusbasket);
            return Ok(id);
        }

        public OrderItems PutUpdateCustomerOrder(OrderItems orders)
        {
            var data = manageOrders.UpdateCustomerOrder(orders);
            return data;
        }


        public OrderItems DeleteCustomerOrder(int orderId)
        {
            var data = manageOrders.DeleteCustomerOrder(orderId);
            return data;
        }

        [HttpGet]
        public OrderItems PostCustomerOrderItems(int orderId, string itemName, int quantity)
        {
            var data = manageOrders.AddOrderItems(orderId, itemName, quantity);
            return data;
        }
        [HttpGet]
        public OrderItems PutCustomerOrderItem(int orderId, string itemName, int quantity)
        {
            var data = manageOrders.UpdateOrderItems(orderId, itemName, quantity);
            return data;
        }
       
        public OrderItems DeleteCustomerOrderItems(int orderId, string itemName, int quantity)
        {
            var data = manageOrders.RemoveOrderItems(orderId, itemName, quantity);
            return data;
        }
       
        public OrderItems DeleteCustomerOrdersList(int orderId)
        {
            var data = manageOrders.ClearCustomerOrderList(orderId);
            return data;
        }

    }
}
