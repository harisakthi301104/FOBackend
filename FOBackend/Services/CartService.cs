using FOBackend.DTOs.Cart;
using FOBackend.Models;
using Microsoft.EntityFrameworkCore;
// using FOBackend.Data; // Phase 0 dependency

namespace FOBackend.Services
{
    public interface ICartService
    {
        Task<CartDto> GetCartAsync(int userId);
        Task<CartDto> AddToCartAsync(int userId, AddToCartDto dto);
        Task<CartDto> UpdateCartItemAsync(int userId, UpdateCartDto dto);
        Task<CartDto> RemoveFromCartAsync(int userId, int cartItemId);
    }

    public class CartService : ICartService
    {
        // private readonly AppDbContext _context;

        // public CartService(AppDbContext context)
        // {
        //     _context = context;
        // }

        public async Task<CartDto> GetCartAsync(int userId)
        {
            throw new NotImplementedException("Waiting for AppDbContext from Phase 0");
        }

        public async Task<CartDto> AddToCartAsync(int userId, AddToCartDto dto)
        {
            throw new NotImplementedException("Waiting for AppDbContext from Phase 0");
        }

        public async Task<CartDto> UpdateCartItemAsync(int userId, UpdateCartDto dto)
        {
            throw new NotImplementedException("Waiting for AppDbContext from Phase 0");
        }

        public async Task<CartDto> RemoveFromCartAsync(int userId, int cartItemId)
        {
            throw new NotImplementedException("Waiting for AppDbContext from Phase 0");
        }
    }
}
