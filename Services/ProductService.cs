using TestPOS.Models;

namespace TestPOS.Services
{
    public class ProductService
    {
        private readonly List<Category> _categories = new()
        {
            new Category { Id = 1, Name = "Bevande", Color = "#007bff", Icon = "🥤" },
            new Category { Id = 2, Name = "Panini", Color = "#28a745", Icon = "🥪" },
            new Category { Id = 3, Name = "Dolci", Color = "#ffc107", Icon = "🍰" },
            new Category { Id = 4, Name = "Fritti", Color = "#dc3545", Icon = "🍟" },
            new Category { Id = 5, Name = "Antipasti", Color = "#6f42c1", Icon = "🧀" },
            new Category { Id = 6, Name = "Primi", Color = "#fd7e14", Icon = "🍝" }
        };

        private readonly List<Product> _products = new()
        {
            // Bevande
            new Product { Id = 1, Name = "Birra Piccola", Description = "Birra chiara 0.3L", Price = 3.50m, CategoryId = 1 },
            new Product { Id = 2, Name = "Birra Media", Description = "Birra chiara 0.5L", Price = 5.00m, CategoryId = 1 },
            new Product { Id = 3, Name = "Vino Bianco", Description = "Calice di vino bianco", Price = 4.00m, CategoryId = 1 },
            new Product { Id = 4, Name = "Vino Rosso", Description = "Calice di vino rosso", Price = 4.00m, CategoryId = 1 },
            new Product { Id = 5, Name = "Acqua", Description = "Acqua naturale 0.5L", Price = 1.50m, CategoryId = 1 },
            new Product { Id = 6, Name = "Coca Cola", Description = "Lattina 0.33L", Price = 2.50m, CategoryId = 1 },
            
            // Panini
            new Product { Id = 7, Name = "Panino Porchetta", Description = "Panino con porchetta", Price = 6.00m, CategoryId = 2 },
            new Product { Id = 8, Name = "Panino Salsiccia", Description = "Panino con salsiccia e peperoni", Price = 6.50m, CategoryId = 2 },
            new Product { Id = 9, Name = "Panino Vegetariano", Description = "Panino con verdure grigliate", Price = 5.50m, CategoryId = 2 },
            new Product { Id = 10, Name = "Hamburger", Description = "Hamburger con patatine", Price = 8.00m, CategoryId = 2 },
            
            // Dolci
            new Product { Id = 11, Name = "Tiramisù", Description = "Tiramisù della casa", Price = 4.50m, CategoryId = 3 },
            new Product { Id = 12, Name = "Gelato", Description = "Gelato artigianale (2 gusti)", Price = 3.50m, CategoryId = 3 },
            new Product { Id = 13, Name = "Cannoli", Description = "Cannoli siciliani", Price = 3.00m, CategoryId = 3 },
            new Product { Id = 14, Name = "Crostata", Description = "Crostata della nonna", Price = 3.50m, CategoryId = 3 },
            
            // Fritti
            new Product { Id = 15, Name = "Patatine Fritte", Description = "Porzione di patatine", Price = 3.00m, CategoryId = 4 },
            new Product { Id = 16, Name = "Olive Ascolane", Description = "6 pezzi", Price = 4.50m, CategoryId = 4 },
            new Product { Id = 17, Name = "Arancini", Description = "Arancini siciliani (2 pezzi)", Price = 5.00m, CategoryId = 4 },
            new Product { Id = 18, Name = "Mozzarella Fritta", Description = "Mozzarella in carrozza", Price = 4.00m, CategoryId = 4 },
            
            // Antipasti
            new Product { Id = 19, Name = "Tagliere Misto", Description = "Salumi e formaggi locali", Price = 12.00m, CategoryId = 5 },
            new Product { Id = 20, Name = "Bruschette", Description = "4 bruschette miste", Price = 6.00m, CategoryId = 5 },
            new Product { Id = 21, Name = "Antipasto Mare", Description = "Frutti di mare misti", Price = 10.00m, CategoryId = 5 },
            
            // Primi
            new Product { Id = 22, Name = "Pasta al Pomodoro", Description = "Pasta fresca al pomodoro", Price = 8.00m, CategoryId = 6 },
            new Product { Id = 23, Name = "Carbonara", Description = "Spaghetti alla carbonara", Price = 9.00m, CategoryId = 6 },
            new Product { Id = 24, Name = "Risotto", Description = "Risotto del giorno", Price = 10.00m, CategoryId = 6 }
        };

        public List<Category> GetCategories() => _categories;
        public List<Product> GetProducts() => _products;
        public List<Product> GetProductsByCategory(int categoryId) => 
            _products.Where(p => p.CategoryId == categoryId).ToList();
        public Product? GetProduct(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}