namespace Shop.API.Core.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser{ get; set; }
        public bool PaymentStatus{ get; set; }
        public List<Cart> Carts{ get; set; }


        public Order()
        {
            Carts = new List<Cart>();
            
            PaymentStatus = false;
        }
    }
}
