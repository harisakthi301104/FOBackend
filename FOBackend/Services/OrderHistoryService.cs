using FOBackend.Data;
using FOBackend.DTOs.Inventory;
using Microsoft.EntityFrameworkCore;

namespace FOBackend.Services;

public interface IOrderHistoryService
{
    Task<List<OrderHistoryDto>> GetUserOrderHistoryAsync(int userId);
    Task<OrderHistoryDto> GetOrderDetailAsync(int orderId, int userId);
}

public class OrderHistoryService : IOrderHistoryService
{
    private readonly AppDbContext _context;

    public OrderHistoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderHistoryDto>> GetUserOrderHistoryAsync(int userId)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .OrderByDescending(o => o.OrderDate)
            .Select(o => new OrderHistoryDto
            {
                OrderId = o.OrderId,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                OrderDate = o.OrderDate,
                Items = o.OrderItems.Select(oi => new OrderHistoryItemDto
                {
                    ItemId = oi.ItemId,
                    ItemName = oi.Item.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            })
            .ToListAsync();
    }

    public async Task<OrderHistoryDto> GetOrderDetailAsync(int orderId, int userId)
    {
        return await _context.Orders
            .Where(o => o.OrderId == orderId && o.UserId == userId)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .Select(o => new OrderHistoryDto
            {
                OrderId = o.OrderId,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                OrderDate = o.OrderDate,
                Items = o.OrderItems.Select(oi => new OrderHistoryItemDto
                {
                    ItemId = oi.ItemId,
                    ItemName = oi.Item.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }
}
