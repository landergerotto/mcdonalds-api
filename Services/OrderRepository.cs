using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace McDonaldsAPI.Services;

using Model;

public class OrderRepository : IOrderRepository
{
    private readonly McDatabaseContext context;
    public OrderRepository(McDatabaseContext context)
        => this.context = context;

    public async Task<int> CreateOrder(int storeId)
    {
        var selectedStore = 
            from store in context.Stores
            where store.Id == storeId
            select store;

        if (!selectedStore.Any())
            throw new Exception("Store does not exist.");

        var ClientOrder = new ClientOrder();
        ClientOrder.StoreId = storeId;
        ClientOrder.OrderCode = "abcd1234";
 
        context.Add(ClientOrder);
        await context.SaveChangesAsync();

        return ClientOrder.Id;
    }
    public async Task CancelOrder(int orderId)
    {
        var currentOrder = await getOrder(orderId);
        if (currentOrder is null)
            throw new Exception("Order does not exist.");

        context.Remove(currentOrder);
        await context.SaveChangesAsync();
    }

    public async Task DeliveryOrder(int orderId)
    {
        var currentOrder = await getOrder(orderId);
        if (currentOrder is null)
            throw new Exception("Order does not exist.");

        currentOrder.DeliveryMoment = DateTime.Now.AddHours(2);

        context.Update(currentOrder);
        await context.SaveChangesAsync();
    }

    public async Task FinishOrder(int orderId)
    {
        var currentOrder = await getOrder(orderId);
        if (currentOrder is null)
            throw new Exception("Order does not exist.");

        currentOrder.FinishMoment = DateTime.Now;

        context.Update(currentOrder);
        await context.SaveChangesAsync();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new System.NotImplementedException();
    }
    public async Task AddItem(int orderId, int productId)
    {
        var order = await getOrder(orderId);
        if (order is null)
            throw new Exception("Order does not exist.");

        var products =
            from product in context.Products
            where product.Id == productId
            select product;
        var selectedProduct = await products.FirstOrDefaultAsync();
        if (selectedProduct is null)
            throw new Exception("Product does not exist.");

        var item = new ClientOrderItem();
        item.ClientOrderId = orderId;
        item.ProductId = productId;

        context.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task RemoveItem(int orderId, int productId)
    {
        var order = await getOrder(orderId);
        if (order is null)
            throw new Exception("Order does not exist.");

        var items =
            from item in context.ClientOrderItems
            where item.ProductId == productId && item.ClientOrderId == orderId
            select item;
        var selectedItem = await items.FirstOrDefaultAsync();
        if (selectedItem is null)
            throw new Exception("Product does not exist.");

        context.Remove(selectedItem);
        await context.SaveChangesAsync();
    }

    private async Task<ClientOrder> getOrder(int orderId)
    {
        var orders = 
            from order in context.ClientOrders
            where order.Id == orderId
            select order;

        return await orders.FirstOrDefaultAsync();
    }
}