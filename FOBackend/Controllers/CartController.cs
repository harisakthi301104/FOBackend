using FOBackend.DTOs.Cart;
using FOBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FOBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize] // Wait for Phase 0 Auth setup
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        private int GetUserId()
        {
            // Parse from JWT Claims
            // return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return 1; // Placeholder
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var cart = await _cartService.GetCartAsync(GetUserId());
            return Ok(cart);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
        {
            var cart = await _cartService.AddToCartAsync(GetUserId(), dto);
            return Ok(cart);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCart([FromBody] UpdateCartDto dto)
        {
            var cart = await _cartService.UpdateCartItemAsync(GetUserId(), dto);
            return Ok(cart);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart([FromQuery] int cartItemId)
        {
            var cart = await _cartService.RemoveFromCartAsync(GetUserId(), cartItemId);
            return Ok(cart);
        }
    }
}
