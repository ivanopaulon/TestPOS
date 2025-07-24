using TestPOS.Models;

namespace TestPOS.Services
{
    public class CartService
    {
        private readonly List<CartItem> _items = new();
        private int _nextReceiptNumber = 1000;

        public event Action? OnCartChanged;

        public List<CartItem> GetItems() => _items;
        public int ItemCount => _items.Sum(i => i.Quantity);
        public decimal Total => _items.Sum(i => i.Total);

        public void AddItem(Product product)
        {
            var existingItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = 1 });
            }
            OnCartChanged?.Invoke();
        }

        public void RemoveItem(Product product)
        {
            var existingItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity--;
                }
                else
                {
                    _items.Remove(existingItem);
                }
                OnCartChanged?.Invoke();
            }
        }

        public void UpdateQuantity(Product product, int quantity)
        {
            var existingItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                if (quantity <= 0)
                {
                    _items.Remove(existingItem);
                }
                else
                {
                    existingItem.Quantity = quantity;
                }
                OnCartChanged?.Invoke();
            }
        }

        public void ClearCart()
        {
            _items.Clear();
            OnCartChanged?.Invoke();
        }

        public Receipt GenerateReceipt()
        {
            var receipt = new Receipt
            {
                ReceiptNumber = _nextReceiptNumber++,
                Items = new List<CartItem>(_items)
            };
            return receipt;
        }

        public Receipt CompleteOrder()
        {
            var receipt = GenerateReceipt();
            ClearCart();
            return receipt;
        }
    }
}