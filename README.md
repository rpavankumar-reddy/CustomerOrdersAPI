# CustomerOrdersAPI
API which will allow users to add and remove items and change the quantity of the items. Users can also be able to simply clear out all items from their order and start again.

Additional functionality of Creating Orders has been implemented.

Different  API endpoints are implemented for adding,updating,deleting orders and also for adding, updating and deleting the items in the order.

The following lines describe how to use the api's for different functionality

1.GetAllOrders - To Get all the orders use the api
http://localhost:[port]/api/CustomerOrders/GetAllOrders which returns
Output
[
  {
    "OrderId": 1,
    "CustomerName": "Mark",
    "Phone": "7777766666",
    "Address": "London",
    "ItemBasketList": [
      {
        "ItemName": "Iphone6",
        "ItemQuantity": 2
      },
      {
        "ItemName": "Galaxy",
        "ItemQuantity": 1
      }
    ]
  }
]

2.GetOrder - To get the particular single order use the api endpoint as
http://localhost:[port]/api/CustomerOrders/GetOrder?orderId=1 
with orderId as input parameter
Output:
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": [
    {
      "ItemName": "Iphone6",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Galaxy",
      "ItemQuantity": 1
    }
  ]
}

3.AddNewOrder - To add a new order use the api 
http://localhost:[port]/api/CustomerOrders/PostCustomerOrder and send the new order asinput
Input:
{
    "OrderId": 2,
    "CustomerName": "Mark2",
    "Phone": "7777666662",
    "Address": "Birmingham",
    "ItemBasketList": [
      {
        "ItemName": "Philips",
        "ItemQuantity": 2
      },
      {
        "ItemName": "Samsung",
        "ItemQuantity": 2
      }
    ]
  }

  The api returns the new order as output
  {
    "OrderId": 2,
    "CustomerName": "Mark2",
    "Phone": "7777666662",
    "Address": "Birmingham",
    "ItemBasketList": [
      {
        "ItemName": "Philips",
        "ItemQuantity": 2
      },
      {
        "ItemName": "Samsung",
        "ItemQuantity": 2
      }
    ]
  }


4.UpdateOrder - to update an existing order use the api
http://localhost:[port]/api/CustomerOrders/PutCustomerOrder with the updated order as input
Input:
{
  "OrderId": 2,
  "CustomerName": "MarkWaugh",
  "Phone": "7775556667",
  "Address": "Houston",
  "ItemBasketList": [
    {
      "ItemName": "Philips",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Samsung",
      "ItemQuantity": 2
    }
  ]
}

The api returns the updated order as output
{
  "OrderId": 2,
  "CustomerName": "MarkWaugh",
  "Phone": "7775556667",
  "Address": "Houston",
  "ItemBasketList": [
    {
      "ItemName": "Philips",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Samsung",
      "ItemQuantity": 2
    }
  ]
}

5.DeleteOrder - To delete an order use the api
http://localhost:[port]/api/CustomerOrders/DeleteCustomerOrder?orderId=2 with orderId as input
Input - orderId
Output - Returns the deleted order

{
  "OrderId": 2,
  "CustomerName": "MarkWaugh",
  "Phone": "7775556667",
  "Address": "Houston",
  "ItemBasketList": [
    {
      "ItemName": "Philips",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Samsung",
      "ItemQuantity": 2
    }
  ]
}

6.AddOrderItems - To add new Items to the order use the api
http://localhost:[port]/api/CustomerOrders/PostCustomerOrderItem?orderId=1&itemName=HTC&quantity=5
with orderId,itemName and quantity as parameter
Input : orderId,itemName,quantity
Output: Returns the Order with added Item
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": [
    {
      "ItemName": "Iphone6",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Galaxy",
      "ItemQuantity": 1
    },
    {
      "ItemName": "HTC",
      "ItemQuantity": 5
    }
  ]
}

7.UpdateOrderItems - To update the items(to change the quantiy) in the order use the api
http://localhost:[port]/api/CustomerOrders/PutCustomerOrderItem?orderId=1&itemName=HTC&quantity=100
with orderId,itemName and quantity as input parameter
Input : orderId,itemName,quantity
Output: Returns the Order with updated quantity in the item
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": [
    {
      "ItemName": "Iphone6",
      "ItemQuantity": 2
    },
    {
      "ItemName": "Galaxy",
      "ItemQuantity": 1
    },
    {
      "ItemName": "HTC",
      "ItemQuantity": 100
    }
  ]
}

8.RemoveOrderItems - To delete an item in the order use the api 
http://localhost:[port]/api/CustomerOrders/DeleteCustomerOrderItem?orderId=1&itemName=Galaxy
with orderId and itemName as parameter
Input : orderId,itemName,quantity
Output: Returns the Order by removing the item
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": [
    {
      "ItemName": "Iphone6",
      "ItemQuantity": 2
    },
    {
      "ItemName": "HTC",
      "ItemQuantity": 100
    }
  ]
}


9.ClearItemsList - To delete all the items in the order use the api
http://localhost:[port]/api/CustomerOrders/DeleteOrderItemsList?orderId=1
with orderId as parameter
Input : orderId
Output: Returns the Order with Empty Items List
{
  "OrderId": 1,
  "CustomerName": "Mark",
  "Phone": "7777766666",
  "Address": "London",
  "ItemBasketList": []
} 

