namespace MultiShop.DtoLayer.OrderDtos.OrderingDtos
{
    public class UpdateOrderDto
    {
        public int OrderingID { get; set; }

        public string UserID { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
