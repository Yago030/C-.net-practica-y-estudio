﻿using backend2.DTOs;

namespace backend2.Services
{
    public interface IBeerService
    {
        Task<IEnumerable<BeerDto>> Get();
        Task<BeerDto> GetById(int id);
        Task<BeerDto> Add(BeerInsertDto beerInsertDto);
        Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto);
    }
}
