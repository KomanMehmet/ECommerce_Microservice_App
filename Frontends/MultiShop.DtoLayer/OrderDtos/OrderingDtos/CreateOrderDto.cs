namespace MultiShop.DtoLayer.OrderDtos.OrderingDtos
{
    public class CreateOrderDto
    {
        public string UserID { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
