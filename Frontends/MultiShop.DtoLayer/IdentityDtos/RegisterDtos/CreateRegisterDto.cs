﻿namespace MultiShop.DtoLayer.IdentityDtos.RegisterDtos
{
    public class CreateRegisterDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
