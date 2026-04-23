using FOBackend.DTOs.Inventory;
using FOBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FOBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrderHistoryController : ControllerBase
{
    private readonly IOrderHistoryService _orderHistoryService;

    public OrderHistoryController(IOrderHistoryService orderHistoryService)
    {
        _orderHistoryService = orderHistoryService;
    }

    /// <summary>
    /// Get order history for the current logged-in user
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<OrderHistoryDto>>> GetOrderHistory()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId))
            return Unauthorized(new { message = "Invalid user token" });

        var orders = await _orderHistoryService.GetUserOrderHistoryAsync(userId);
        return Ok(orders);
    }

    /// <summary>
    /// Get details of a specific order
    /// </summary>
    [HttpGet("{orderId}")]
    public async Task<ActionResult<OrderHistoryDto>> GetOrderDetail(int orderId)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!int.TryParse(userIdClaim, out var userId))
            return Unauthorized(new { message = "Invalid user token" });

        var order = await _orderHistoryService.GetOrderDetailAsync(orderId, userId);
        if (order == null)
            return NotFound(new { message = "Order not found or does not belong to this user" });

        return Ok(order);
    }
}
