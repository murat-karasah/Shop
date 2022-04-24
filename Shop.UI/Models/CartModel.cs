namespace Shop.UI.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public int? OrderId { get; set; }
        public bool Status { get; set; }
    }
}
