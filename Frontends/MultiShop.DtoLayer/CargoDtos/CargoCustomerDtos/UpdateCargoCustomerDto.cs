﻿namespace MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos
{
    public class UpdateCargoCustomerDto
    {
        public int CargoCustomerID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string UserCustomerID { get; set; }
    }
}
