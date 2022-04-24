namespace Shop.API.Core.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser{ get; set; }
        public int? CartID { get; set; }
        public Cart Cart { get; set; }
        public bool PaymentStatus{ get; set; }
        public bool Status{ get; set; }
        public decimal total{ get; set; }


       
    }
}
