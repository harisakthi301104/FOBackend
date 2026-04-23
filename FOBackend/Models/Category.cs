using System;
using System.Collections.Generic;

namespace FOBackend.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
