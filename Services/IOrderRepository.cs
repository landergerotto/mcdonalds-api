using System.Threading.Tasks;
using System.Collections.Generic;

namespace McDonaldsAPI.Services;

using Model;

public interface IOrderRepository
{
    Task<int> CreateOrder(int storeId);
    Task CancelOrder(int orderId);
    Task<List<Product>> GetMenu(int storeId);
    Task<List<Product>> GetOrderItems(int storeId);
    Task AddItem(int orderId, int productId);
    Task RemoveItem(int orderId, int productId);
    Task FinishOrder(int orderId);
    Task DeliveryOrder(int orderId);
}