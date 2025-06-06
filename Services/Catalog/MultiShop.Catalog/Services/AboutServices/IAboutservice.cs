﻿using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutservice
    {
        Task<List<ResultAboutDto>> GetAllAboutAsync();

        Task CreateAboutAsync(CreateAboutDto createAboutDto);

        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);

        Task DeleteAboutAsync(string id);

        Task<GetByIdAboutDto> GetByIdAboutAsync(string id);
    }
}
