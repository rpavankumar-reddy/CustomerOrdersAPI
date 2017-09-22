using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementAPI.Custom
{
    public class ManageOrders:IManageOrders
    {
        List<OrderItems> cusList = new List<OrderItems>
        {
            new OrderItems
            {
                OrderId = 1, CustomerName = "Mark", Phone = "7777766666", Address = "London",ItemBasketList= new List<Items>
                {
                    new Items { ItemName = "Iphone6",ItemQuantity = 2 },
                    new Items { ItemName = "Galaxy",  ItemQuantity = 1 }

                }
            }
        };

        public List<OrderItems> GetAllOrders()
        {
            return cusList;
        }


        public OrderItems GetCustomerOrders(int orderId)
        {
            return cusList.FirstOrDefault(c => c.OrderId == orderId);
        }

        public OrderItems AddCustomerOrder(OrderItems customerOrder)
        {

            if (customerOrder == null)
            {
                throw new ArgumentNullException("item");
            }
            var itemToRemove = cusList.SingleOrDefault(r => r.OrderId == customerOrder.OrderId);
            if (itemToRemove != null)
            {
                throw new Exception("CustomerBasket Id already exists");
            }
            cusList.Add(customerOrder);           
            return customerOrder;
        }
       
        public OrderItems UpdateCustomerOrder(OrderItems customerOrder)
        {
            var item = cusList.SingleOrDefault(r => r.OrderId == customerOrder.OrderId);
            if (item != null)
            {
                cusList.Remove(item);
            }
            else
            {
                throw new Exception("Userbasket not existed");
            }           
            cusList.Add(customerOrder);
            return customerOrder;
        }

        //Deletes the customer order
        public OrderItems DeleteCustomerOrder(int orderId)
        {
            var itemToRemove = cusList.SingleOrDefault(r => r.OrderId == orderId);
            if (itemToRemove != null)
            {               
                cusList.Remove(itemToRemove);
            }
            return itemToRemove;
        }


        public OrderItems AddOrderItems(int orderId, string itemName, int quantity)
        {

            var custbasket = cusList.SingleOrDefault(r => r.OrderId == orderId);

            if (custbasket != null)
            {
                List<Items> ItemBasketList = custbasket.ItemBasketList;
                var basketitem = ItemBasketList.SingleOrDefault(r => r.ItemName == itemName);
                if (basketitem != null)
                    throw new Exception("Items already exists");
                Items item = new Models.Items();
                item.ItemName = itemName;
                item.ItemQuantity = quantity;
                ItemBasketList.Add(item);
                custbasket.ItemBasketList = ItemBasketList;
            }
            return custbasket;
        }
        public OrderItems RemoveOrderItems(int orderId, string itemName, int quantity)
        {

            var custbasket = cusList.SingleOrDefault(r => r.OrderId == orderId);

            if (custbasket != null)
            {
                List<Items> ItemBasketList = custbasket.ItemBasketList;
                var basketitem = ItemBasketList.SingleOrDefault(r => r.ItemName == itemName);
                if (basketitem != null)
                    ItemBasketList.Remove(basketitem);

                custbasket.ItemBasketList = ItemBasketList;
            }
            return custbasket;
        }

        public OrderItems UpdateOrderItems(int orderId, string itemName, int quantity)
        {
            var custbasket = cusList.SingleOrDefault(r => r.OrderId == orderId);

            if (custbasket != null)
            {
                List<Items> ItemBasketList = custbasket.ItemBasketList;
                var basketitem = ItemBasketList.SingleOrDefault(r => r.ItemName == itemName);
                if (basketitem != null)
                    ItemBasketList.Remove(basketitem);
                Items item = new Models.Items();
                item.ItemName = itemName;
                item.ItemQuantity = quantity;
                ItemBasketList.Add(item);
                custbasket.ItemBasketList = ItemBasketList;
            }
            return custbasket;
        }

        public OrderItems ClearCustomerOrderList(int orderId)
        {
            var custbasket = cusList.SingleOrDefault(r => r.OrderId == orderId);

            if (custbasket != null)
            {
                List<Items> ItemBasketList = custbasket.ItemBasketList;

                ItemBasketList.Clear();
                custbasket.ItemBasketList = ItemBasketList;
            }
            return custbasket;
        }
    }
}