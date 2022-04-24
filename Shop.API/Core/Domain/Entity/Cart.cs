using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.API.Core.Domain.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public bool Status { get; set; }
        public List<CartItem> CartItems { get; set; }



    }
}
