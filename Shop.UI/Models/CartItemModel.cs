namespace Shop.UI.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public decimal ProducPrice { get; set; }
        public int ProducAmount { get; set; }
    }
}
