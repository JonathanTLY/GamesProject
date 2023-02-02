using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamesProject.Server.Data;
using GamesProject.Shared.Domain;
using GamesProject.Server.IRepository;

namespace GamesProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeRatingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AgeRatingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/AgeRatings
        [HttpGet]
        public async Task<IActionResult> GetAgeRatings()
        {
            var AgeRatings = await _unitOfWork.AgeRatings.GetAll();
            return Ok(AgeRatings);
        }

        // GET: api/AgeRatings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgeRating(int id)
        {
            var AgeRating = await _unitOfWork.AgeRatings.Get(q => q.Id == id); ;

            if (AgeRating == null)
            {
                return NotFound();
            }

            return Ok(AgeRating);
        }

        // PUT: api/AgeRatings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgeRating(int id, AgeRating AgeRating)
        {
            if (id != AgeRating.Id)
            {
                return BadRequest();
            }

            _unitOfWork.AgeRatings.Update(AgeRating);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AgeRatingExists(id))
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

        // POST: api/AgeRatings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AgeRating>> PostAgeRating(AgeRating AgeRating)
        {
            await _unitOfWork.AgeRatings.Insert(AgeRating);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetAgeRating", new { id = AgeRating.Id }, AgeRating);
        }

        // DELETE: api/AgeRatings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgeRating(int id)
        {
            var AgeRating = await _unitOfWork.AgeRatings.Get(q => q.Id == id);
            if (AgeRating == null)
            {
                return NotFound();
            }

            await _unitOfWork.AgeRatings.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> AgeRatingExists(int id)
        {
            var AgeRating = await _unitOfWork.AgeRatings.Get(q => q.Id == id);
            return AgeRating != null;
        }
    }
}
