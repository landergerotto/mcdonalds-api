using System;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace McDonaldsAPI.Services;

using Model;

public class FakeOrderRepository : IOrderRepository
{
    int orderId = 42;

    public Task AddItem(int orderId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task CancelOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateOrder(int storeId)
    {
        return orderId; // noice
    }

    public Task DeleveryOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task FinishOrder(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetMenu(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetOrderItems(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveItem(int orderId, int productId)
    {
        throw new NotImplementedException();
    }
}