namespace Shop.API.Core.Application.Dto
{
    public class CartListDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int AppUserID { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
