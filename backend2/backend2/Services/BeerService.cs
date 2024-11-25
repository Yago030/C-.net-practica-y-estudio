using backend2.DTOs;
using backend2.Models;
using Microsoft.EntityFrameworkCore;

namespace backend2.Services
{
    public class BeerService : IBeerService
    {
        private StoreContext _context;

        public BeerService(StoreContext context)
        {
            _context = context;
        }

        public Task<BeerDto> Add(BeerInsertDto beerInsertDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BeerDto>> Get() =>
        
            await _context.Beers.Select(b => new BeerDto
            {
                Id = b.BeerID,
                Name = b.BeerName,
                BrandId = b.BrandID
            }).ToListAsync();
        

        public Task<BeerDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BeerDto> Update(int id, BeerUpdateDto beerUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
