using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatingApp_FullSD.Server.Data;
using DatingApp_FullSD.Shared.Domain;
using DatingApp_FullSD.Server.IRepository;
using DatingApp_FullSD.Server.Repository;
using Microsoft.CodeAnalysis.CSharp;

namespace DatingApp_FullSD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatchesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Matches
        [HttpGet]

        public async Task<IActionResult> GetMatches()
        {
            var matches = await _unitOfWork.Posts.GetAll();
            return Ok(matches);
        }

        // GET: api/Matches/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await _unitOfWork.Matches.Get(q => q.Id == id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // PUT: api/Matches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatch(int id, Match match)
        {
            if (id != match.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Matches.Update(match);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!await MatchExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();

        }

        // POST: api/Matchs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(Match match)
        {
            await _unitOfWork.Matches.Insert(match);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMatch", new { id = match.Id }, match);
        }

        // DELETE: api/Match/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            var match = await _unitOfWork.Matches.Get(q => q.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            await _unitOfWork.Matches.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }



        private async Task<bool> MatchExists(int id)
        {
            var match = await _unitOfWork.Matches.Get(q => q.Id == id);
            return match != null;
        }
    }
}
