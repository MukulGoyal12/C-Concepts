using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuctionAPI.Models;

namespace AuctionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly AuctionContext _context;

        public AdvertisementController(AuctionContext context)
        {
            _context = context;
        }

        // GET: api/Advertisement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advertisement>>> GetAdvertisements()
        {
            return await _context.Advertisements.ToListAsync();
        }

        // GET: api/Advertisement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Advertisement>> GetAdvertisement(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return advertisement;
        }

        // PUT: api/Advertisement/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvertisement(int id, AdvertisementDTO advertisement)
        {
            Advertisement ad = new Advertisement()
            {
                Id = id,
                ProductName=advertisement.ProductName,
                BasePrice=advertisement.BasePrice,
                Description=advertisement.Description,
                ItemImage=advertisement.ItemImage,
                CreateDate=advertisement.CreateDate,
                Bids= []
            };
            if (id != ad.Id)
            {
                return BadRequest();
            }

            _context.Entry(ad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Advertisement
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Advertisement>> PostAdvertisement(AdvertisementDTO adto)
        {//validation
            Advertisement advertisement =new Advertisement();
             
            advertisement.ProductName = adto.ProductName;
            advertisement.BasePrice = adto.BasePrice;
            advertisement.Description = adto.Description;
            advertisement.CreateDate = DateTime.Now;
            advertisement.ItemImage = adto.ItemImage;
            _context.Advertisements.Add(advertisement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvertisement", new { id = advertisement.Id }, advertisement);
        }

        // DELETE: api/Advertisement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }

            _context.Advertisements.Remove(advertisement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdvertisementExists(int id)
        {
            return _context.Advertisements.Any(e => e.Id == id);
        }
    }
}
