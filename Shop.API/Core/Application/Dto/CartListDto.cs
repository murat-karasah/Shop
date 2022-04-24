namespace Shop.API.Core.Application.Dto
{
    public class CartListDto
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public int? OrderId { get; set; }
        public bool Status { get; set; }
    }
}
