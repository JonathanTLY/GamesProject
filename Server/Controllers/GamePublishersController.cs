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
    public class GamePublishersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamePublishersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/GamePublishers
        [HttpGet]
        public async Task<IActionResult> GetGamePublishers()
        {
            var GamePublishers = await _unitOfWork.GamePublishers.GetAll();
            return Ok(GamePublishers);
        }

        // GET: api/GamePublishers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGamePublisher(int id)
        {
            var GamePublisher = await _unitOfWork.GamePublishers.Get(q => q.Id == id); ;

            if (GamePublisher == null)
            {
                return NotFound();
            }

            return Ok(GamePublisher);
        }

        // PUT: api/GamePublishers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamePublisher(int id, GamePublisher GamePublisher)
        {
            if (id != GamePublisher.Id)
            {
                return BadRequest();
            }

            _unitOfWork.GamePublishers.Update(GamePublisher);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await GamePublisherExists(id))
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

        // POST: api/GamePublishers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GamePublisher>> PostGamePublisher(GamePublisher GamePublisher)
        {
            await _unitOfWork.GamePublishers.Insert(GamePublisher);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetGamePublisher", new { id = GamePublisher.Id }, GamePublisher);
        }

        // DELETE: api/GamePublishers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamePublisher(int id)
        {
            var GamePublisher = await _unitOfWork.GamePublishers.Get(q => q.Id == id);
            if (GamePublisher == null)
            {
                return NotFound();
            }

            await _unitOfWork.GamePublishers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> GamePublisherExists(int id)
        {
            var GamePublisher = await _unitOfWork.GamePublishers.Get(q => q.Id == id);
            return GamePublisher != null;
        }
    }
}
