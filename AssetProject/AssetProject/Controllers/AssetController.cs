using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AssetProject.Model;

namespace AssetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly AssetDBContext _context;

        public AssetController(AssetDBContext context)
        {
            _context = context;
        }

        // GET: api/Asset
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            if (_context.Assets == null)
            {
                return NotFound();
            }
            return await _context.Assets.ToListAsync();
        }

        // GET: api/Asset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(int id)
        {
            if (_context.Assets == null)
            {
                return NotFound();
            }
            var asset = await _context.Assets.FindAsync(id);

            if (asset == null)
            {
                return NotFound();
            }

            return asset;
        }

        // PUT: api/Asset/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsset(int id, Asset asset)
        {
            if (id != asset.ID)
            {
                return BadRequest();
            }

            _context.Entry(asset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetExists(id))
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

        // POST: api/Asset
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(Asset asset)
        {
          //if (_context.Assets == null)
          //{
          //    return Problem("Entity set 'AssetDBContext.Assets'  is null.");
          //}
            var temp = _context.Assets.Where(x =>
   x.ID == asset.ID && x.Name == asset.Name && x.Brand == asset.Brand && x.Model == asset.Model&& x.Country==asset.Country && x.Date == asset.Date && x.Price ==asset.Price).FirstOrDefault();

            if(temp == null)
            {
                _context.Assets.Add(asset);
                await _context.SaveChangesAsync();
            }
            else
            {
                asset = temp;
            }
            return Ok(asset);


            //return CreatedAtAction("GetAsset", new { id = asset.ID }, asset);
        }

        // DELETE: api/Asset/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsset(int id)
        {
            if (_context.Assets == null)
            {
                return NotFound();
            }
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }

            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssetExists(int id)
        {
            return (_context.Assets?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
