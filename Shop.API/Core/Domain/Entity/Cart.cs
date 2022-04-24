using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.API.Core.Domain.Entity
{
    public class Cart
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        [ForeignKey("AppUserID")]
     
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order Order{ get; set; }
        

    }
}
