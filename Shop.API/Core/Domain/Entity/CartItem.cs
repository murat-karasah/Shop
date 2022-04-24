namespace Shop.API.Core.Domain.Entity
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public decimal ProducPrice { get; set; }
        public int ProducAmount { get; set; }
        public Product Product { get; set; }

    }
}
