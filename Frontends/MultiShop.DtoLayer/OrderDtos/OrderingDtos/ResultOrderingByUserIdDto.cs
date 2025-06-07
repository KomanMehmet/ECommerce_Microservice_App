namespace MultiShop.DtoLayer.OrderDtos.OrderingDtos
{
    public class ResultOrderingByUserIdDto
    {
        public int OrderingID { get; set; }

        public string UserID { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
