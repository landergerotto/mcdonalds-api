using System;
using System.Linq;
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

        if (selectedStore.Count() == 0)
            throw new Exception("Store does not exist.");

        var ClientOrder = new ClientOrder();
        ClientOrder.StoreId = storeId;
        ClientOrder.OrderCode = "abcd1234";

        context.Add(ClientOrder);
        await context.SaveChangesAsync();

        return ClientOrder.Id;
    }
    public Task CancelOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task AddItem(int orderId, int itemId)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleveryOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new System.NotImplementedException();
    }

    public Task RemoveItem(int orderId, int itemId)
    {
        throw new System.NotImplementedException();
    }
}