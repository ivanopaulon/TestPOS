namespace TestPOS.Models
{
    public class Receipt
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public int ReceiptNumber { get; set; }
        public List<CartItem> Items { get; set; } = new();
        public decimal Subtotal => Items.Sum(i => i.Total);
        public decimal Tax => Subtotal * 0.22m; // 22% IVA
        public decimal Total => Subtotal + Tax;
        public string PaymentMethod { get; set; } = "Contanti";
    }
}