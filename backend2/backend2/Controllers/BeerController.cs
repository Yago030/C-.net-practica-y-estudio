using backend2.DTOs;
using backend2.Models;
using backend2.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {

        private  StoreContext _context;
        private IValidator<BeerInsertDto> _beerInsertValidator;
        private IValidator<BeerUpdateDto> _beerUpdateValidator; //lo declaramos
        private IBeerService _beerService;

        public BeerController( StoreContext context, IValidator<BeerInsertDto> beerInsertValidator, IValidator<BeerUpdateDto> beerUpdateValidator,
            IBeerService beerService) //primero lo añadimos en parametros 
        {
            _context = context;
            _beerInsertValidator = beerInsertValidator;
            _beerUpdateValidator = beerUpdateValidator;
            _beerService = beerService;

        }

        [HttpGet]
        public async Task<IEnumerable<BeerDto>> Get() =>
           await _beerService.Get();




        [HttpGet("{id}")]
        public async Task<ActionResult<BeerDto>> GetById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null)
            {
                return NotFound();
            }

            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.BeerName
            };

            return Ok(beerDto);
        }

        [HttpPost]
        public async Task<ActionResult<BeerDto>> Add(BeerInsertDto beerInsertDto)
        {
            
            var validationResult = await _beerInsertValidator.ValidateAsync(beerInsertDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            var beer = new Beer()
            {
                BeerName = beerInsertDto.Name,
                BrandID = beerInsertDto.BrandID
            };

            await _context.Beers.AddAsync(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.BeerName,
                BrandId = beer.BrandID
            };


            return CreatedAtAction(nameof(GetById), new { id = beer.BeerID }, beerDto);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<BeerDto>> Update(int id, BeerUpdateDto beerUpdateDto)
        {

            var validationResult = await _beerUpdateValidator.ValidateAsync(beerUpdateDto); //que vamos a validar


            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var beer = await _context.Beers.FindAsync(id);

            if(beer == null)
            {
                return NotFound();
            }

            beer.BeerName = beerUpdateDto.Name;
            beer.BrandID = beer.BrandID;

            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerID,
                Name = beer.BeerName,
                BrandId = beer.BrandID
            };


            return Ok(beerDto);

        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer == null)
            {
                return NotFound();
            }
            _context.Beers.Remove(beer);

            await _context.SaveChangesAsync();

            return Ok();
        }



    }





}
