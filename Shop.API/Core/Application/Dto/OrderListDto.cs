namespace Shop.API.Core.Application.Dto
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public int? CartID { get; set; }
        public bool PaymentStatus { get; set; }
        public bool Status { get; set; }
        public decimal total { get; set; }
    }
}
